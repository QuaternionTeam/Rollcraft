using System.Collections.Generic;
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
    private const int width = 5, height = 9;
    internal static int realWidth = width * 2 - 1, realHeight = height * 2 - 1;
    private const float squareSize = 1.25f;

    [SerializeField] private GameObject emptyPrefab, finalBossPrefab, combatPrefab, eliteCombatPrefab, rerollPrefab;
    [SerializeField] private Player player;

    private Square[,] grid = new Square[realWidth, realHeight];
    private static int playerGridLocationX = -1, playerGridLocationY = -1;

    private static readonly List<List<Enemy>> combats = new List<List<Enemy>> {
        new List<Enemy> { },
        new List<Enemy> { },
        new List<Enemy> { },
        new List<Enemy> { },
        new List<Enemy> { }
    };

    void Start()
    {
        transform.position = new Vector3(-realWidth * squareSize / 2, -realHeight * squareSize / 2, 0f);
        Initialize();
    }

    private Square InstantiateSquare(GameObject prefab, int gridPosX, int gridPosY)
    {
        Square newSquare = Instantiate(prefab, Vector3.zero, Quaternion.identity, transform).GetComponent<Square>();
        newSquare.transform.localPosition = new Vector3(gridPosX * squareSize, gridPosY * squareSize, 0);
        newSquare.Initialize(this, gridPosX, gridPosY);
        grid[gridPosX - 1, gridPosY - 1] = newSquare;
        return newSquare;
    }

    private int chests = 0;
    private List<int> chestList = new List<int>();
    private Square InstantiateCombatOrChest(int gridPosX, int gridPosY)
    {
        if (chests < 4 && Random.Range(0f, 1f) < 0.3 && gridPosY > 4 && !chestList.Contains(gridPosX)) {
            chests++;
            chestList.Add(gridPosX);
            return InstantiateSquare(rerollPrefab, gridPosX, gridPosY);
        }
        else
            return InstantiateSquare(combatPrefab, gridPosX, gridPosY);
    }

    private void Initialize()
    {
        if (!GameData.instance.generated)
        {
            GenerateRandomBoard();
            for (int posX = 0; posX < realWidth; posX++)
            {
                for (int posY = 0; posY < realHeight; posY++)
                {
                    if (grid[posX, posY])
                        GameData.instance.grid[posX, posY] = grid[posX, posY].Type();
                    else
                        GameData.instance.grid[posX, posY] = SquareType.Null;
                }
            }
            GameData.instance.generated = true;
        }
        else
        {
            for (int posX = 1; posX <= realWidth; posX++)
            {
                for (int posY = 1; posY <= realHeight; posY++)
                {
                    if (GameData.instance.grid[posX - 1, posY - 1] == SquareType.Empty)
                        InstantiateSquare(emptyPrefab, posX, posY);
                    else if (GameData.instance.grid[posX - 1, posY - 1] == SquareType.Combat)
                        InstantiateSquare(combatPrefab, posX, posY);
                    else if (GameData.instance.grid[posX - 1, posY - 1] == SquareType.Rerroll)
                        InstantiateSquare(rerollPrefab, posX, posY);
                    else if (GameData.instance.grid[posX - 1, posY - 1] == SquareType.FinalBoss)
                        InstantiateSquare(finalBossPrefab, posX, posY);
                }
            }
            player.transform.position = grid[playerGridLocationX - 1, playerGridLocationY - 1].transform.position;
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -1f);
            player.Activate();
        }
    }

    private void GenerateRandomBoard()
    {
        chests = 0;
        chestList = new List<int>();

        // Start at final position
        int finalPosX = (realWidth + 1) / 2;
        int finalPosY = realHeight;
        InstantiateSquare(finalBossPrefab, finalPosX, finalPosY);

        // Final branches
        InstantiateSquare(emptyPrefab, finalPosX - 1, finalPosY - 1);
        InstantiateSquare(emptyPrefab, finalPosX + 1, finalPosY - 1);

        // Main branches
        foreach (int posX in new int[] { finalPosX - 2, finalPosX, finalPosX + 2 })
            for (int posY = finalPosY - 1; posY >= 2; posY -= 2)
            {
                InstantiateSquare(emptyPrefab, posX, posY);
                InstantiateCombatOrChest(posX, posY - 1);
            }

        // Border branches
        foreach (int posX in new int[] { finalPosX - 4, finalPosX + 4 })
        {
            int maxPosY = Random.Range(3, 8) * 2;
            for (int posY = maxPosY; posY >= 2; posY -= 2)
            {
                InstantiateSquare(emptyPrefab, posX, posY);
                InstantiateCombatOrChest(posX, posY - 1);
            }
            InstantiateSquare(emptyPrefab, finalPosX + ((posX - finalPosX) / 4 * 3), maxPosY);
        }
    }

    internal bool IsSelectable(int gridPosX, int gridPosY)
    {
        if (playerGridLocationX == -1)
            return gridPosY == 1;
        return PathFind(new Vector2Int(playerGridLocationX, playerGridLocationY), new Vector2Int(gridPosX, gridPosY), new List<Vector2Int>());
    }

    internal bool IsWalkable(Vector2Int gridPos)
    {
        return
            gridPos.x >= 1 && gridPos.y >= 1 &&
            gridPos.x <= realWidth && gridPos.y <= realHeight &&
            grid[gridPos.x - 1, gridPos.y - 1] && grid[gridPos.x - 1, gridPos.y - 1].Walkable();
    }

    internal bool PathFind(Vector2Int gridPos, Vector2Int targetPos, List<Vector2Int> path)
    {
        path.Add(gridPos);
        if (gridPos == targetPos)
            return true;
        
        Vector2Int left = new Vector2Int(gridPos.x - 1, gridPos.y);
        Vector2Int right = new Vector2Int(gridPos.x + 1, gridPos.y);
        Vector2Int up = new Vector2Int(gridPos.x, gridPos.y + 1);

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

    internal void MovePlayer(int gridPosX, int gridPosY)
    {
        player.Activate();
        player.transform.position = grid[gridPosX - 1, gridPosY - 1].transform.position;
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -1f);
        playerGridLocationX = gridPosX;
        playerGridLocationY = gridPosY;
    }

    internal static List<Enemy> GetRandomList()
    {
        int index = Random.Range(0, combats.Count);
        List<Enemy> combat = combats[index];
        return combat;
    }
}
