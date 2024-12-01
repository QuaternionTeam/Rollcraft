using UnityEngine.SceneManagement;

public class FinalBossSquare : Square
{
    internal override bool Walkable() => false;

    internal override void OnMouseDown()
    {
        if (board.IsSelectable(gridPosition))
        {
            //board.MovePlayer(gridPosX, gridPosY);
            AudioManager.Instance.PlayClickSound();
            CombatInitializationData.gridPosition = gridPosition;
            //CombatSystem.enemies = Board.GetRandomList();
            SceneManager.LoadScene("Combat");
        }
    }

    internal override SquareType Type() => SquareType.FinalBoss;
}
