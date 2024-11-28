using UnityEngine.SceneManagement;
using UnityEngine;

public class FinalBossSquare : Square
{
    internal override bool Walkable() => false;

    internal override void OnMouseDown()
    {
        if (board.IsSelectable(gridPosX, gridPosY))
        {
            //board.MovePlayer(gridPosX, gridPosY);
            AudioManager.Instance.PlayClickSound();
            CombatInitializationData.gridPosition = new Vector2Int(gridPosX, gridPosY);
            //CombatSystem.enemies = Board.GetRandomList();
            SceneManager.LoadScene("Combat");
        }
    }

    internal override SquareType Type() => SquareType.FinalBoss;
}
