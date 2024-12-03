using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

enum SquareType
{
    Null,
    Empty,
    Combat,
    Rerroll,
    FinalBoss
}

public class Board : MonoBehaviour
{
    private static readonly Vector2Int walkableSize = new(5, 10);
    internal static readonly Vector2Int gridSize = walkableSize * 2 + new Vector2Int(1, 1);
    private const float squareSize = 1.25f;

    [SerializeField] private GameObject emptyPrefab, finalBossPrefab, combatPrefab, eliteCombatPrefab, rerollPrefab;
    [SerializeField] private Player player;
    [SerializeField] private WorldSizeCamera worldSizeCamera;

    private readonly Grid<Square> grid = new(gridSize, squareSize);
    private static Vector2Int playerGridLocation = new((gridSize.x - 1) / 2, 0);

    //[SerializeField] internal Enemy wolf, alphaWolf, goblin, goblinLancer, goblinLeader;

    void Start()
    {
        //combat = new List<Enemy> { wolf, wolf, wolf };
        transform.position = - grid.WorldSize / 2;
        Initialize();
    }

    private Square InstantiateSquare(GameObject prefab, Vector2Int gridPosition)
    {
        Square newSquare = Instantiate(prefab, Vector3.zero, Quaternion.identity, transform).GetComponent<Square>();
        newSquare.transform.localPosition = grid.CellWorldPositionCentered(gridPosition);
        newSquare.Initialize(this, gridPosition);
        grid.SetCell(gridPosition, newSquare);
        return newSquare;
    }

    private int chests = 0;
    private List<int> chestList = new();
    private Square InstantiateCombatOrChest(Vector2Int gridPosition)
    {
        if (chests < 4 && Random.Range(0f, 1f) < 0.3 && gridPosition.y > 4 && !chestList.Contains(gridPosition.x)) {
            chests++;
            chestList.Add(gridPosition.x);
            return InstantiateSquare(rerollPrefab, gridPosition);
        }
        else
            return InstantiateSquare(combatPrefab, gridPosition);
    }

    private void Initialize()
    {
        if (!GameData.Instance.generated)
        {
            GenerateRandomBoard();
            foreach((Vector2Int gridPosition, Square square) in grid.Cells())
                GameData.Instance.grid[gridPosition.x, gridPosition.y] = square ? square.Type() : SquareType.Null;
            GameData.Instance.generated = true;
        }
        else
        {
            foreach (Vector2Int gridPosition in grid.Positions())
            {
                SquareType squareType = GameData.Instance.grid[gridPosition.x, gridPosition.y];
                GameObject newSquarePrefab = null;
                if (squareType == SquareType.Empty)
                    newSquarePrefab = emptyPrefab;
                else if (squareType == SquareType.Combat)
                    newSquarePrefab = combatPrefab;
                else if (squareType == SquareType.Rerroll)
                    newSquarePrefab = rerollPrefab;
                else if (squareType == SquareType.FinalBoss)
                    newSquarePrefab = finalBossPrefab;
                if (newSquarePrefab)
                    InstantiateSquare(newSquarePrefab, gridPosition);
            }
        }

        // Set player position
        player.transform.position = grid.GetCell(playerGridLocation).transform.position;
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -1f);

        // Activate glow
        foreach ((Vector2Int gridPosition, Square square) in grid.Cells())
            if (square != null && IsSelectable(gridPosition))
                square.ActivateGlow();

        // Move player after victory
        if (CombatInitializationData.victory)
            MovePlayer(CombatInitializationData.gridPosition);

        // Set view
        worldSizeCamera.SetTargetWorldSize(grid.WorldSize + new Vector2(2, 2));
    }

    private void GenerateRandomBoard()
    {
        chests = 0;
        chestList = new List<int>();

        // Start at final position
        int finalPosX = (gridSize.x - 1) / 2;
        int finalPosY = gridSize.y - 1;
        InstantiateSquare(finalBossPrefab, new Vector2Int(finalPosX, finalPosY));

        // Final branches
        InstantiateSquare(emptyPrefab, new Vector2Int(finalPosX - 1, finalPosY - 1));
        InstantiateSquare(emptyPrefab, new Vector2Int(finalPosX + 1, finalPosY - 1));

        // Main branches
        foreach (int posX in new int[] { finalPosX - 2, finalPosX, finalPosX + 2 })
            for (int posY = finalPosY - 1; posY > 1; posY -= 2)
            {
                InstantiateSquare(emptyPrefab, new Vector2Int(posX, posY));
                InstantiateCombatOrChest(new Vector2Int(posX, posY - 1));
            }

        // Border branches
        foreach (int posX in new int[] { finalPosX - 4, finalPosX + 4 })
        {
            int maxPosY = Random.Range(3, 8) * 2 + 1;
            for (int posY = maxPosY; posY > 1; posY -= 2)
            {
                InstantiateSquare(emptyPrefab, new Vector2Int(posX, posY));
                InstantiateCombatOrChest(new Vector2Int(posX, posY - 1));
            }
            InstantiateSquare(emptyPrefab, new Vector2Int(finalPosX + ((posX - finalPosX) / 4 * 3), maxPosY));
        }

        // Player start
        foreach (int posX in new int[] { finalPosX - 4,  finalPosX - 2, finalPosX, finalPosX + 2, finalPosX + 4 })
            InstantiateSquare(emptyPrefab, new Vector2Int(posX, 1));
        foreach (int posX in new int[] { finalPosX - 3, finalPosX - 1, finalPosX + 1, finalPosX + 3 })
            InstantiateSquare(emptyPrefab, new Vector2Int(posX, 1));
        InstantiateSquare(emptyPrefab, new Vector2Int(finalPosX, 0));
    }

    internal bool IsSelectable(Vector2Int gridPosition)
    {
        if (gridPosition == playerGridLocation)
            return false;
        return PathFind(playerGridLocation, gridPosition, new List<Vector2Int>());
    }

    internal bool IsWalkable(Vector2Int gridPosition)
    {
        return
            gridPosition.x >= 0 && gridPosition.y >= 0 &&
            gridPosition.x < gridSize.x && gridPosition.y < gridSize.y &&
            grid.GetCell(gridPosition) && grid.GetCell(gridPosition).Walkable();
    }

    internal bool PathFind(Vector2Int gridPos, Vector2Int targetPos, List<Vector2Int> path)
    {
        path.Add(gridPos);
        if (gridPos == targetPos)
            return true;
        
        Vector2Int left = new(gridPos.x - 1, gridPos.y);
        Vector2Int right = new(gridPos.x + 1, gridPos.y);
        Vector2Int up = new(gridPos.x, gridPos.y + 1);

        if (left == targetPos || right == targetPos || up == targetPos)
            return true;

        if (!path.Contains(left) && IsWalkable(left) && PathFind(left, targetPos, path))
            return true;
        if (!path.Contains(right) && IsWalkable(right) && PathFind(right, targetPos, path))
            return true;
        if (!path.Contains(up) && IsWalkable(up) && PathFind(up, targetPos, path))
            return true;
        return false;
    }

    internal void MovePlayer(Vector2Int gridPosition)
    {
        player.Activate();
        player.transform.position = grid.GetCell(gridPosition).transform.position;
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -1f);
        playerGridLocation = gridPosition;
    }

    // private static List<List<Enemy>> combats = null;
    //private static List<Enemy> combat = null;
    /*internal static List<Enemy> GetRandomList()
    {
        // if (combats == null)
        // {
        //     List<List<Enemy>> combats = new List<List<Enemy>> {
        //         new List<Enemy> { },
        //         new List<Enemy> { },
        //         new List<Enemy> { },
        //         new List<Enemy> { },
        //         new List<Enemy> { }
        //     };
        // }
        // 
        // int index = Random.Range(0, combats.Count);
        // List<Enemy> combat = combats[index];
        // return combat;
        return combat;
    }*/
}
