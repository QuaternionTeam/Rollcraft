using NUnit.Framework;
using UnityEngine.SceneManagement;

public class CombatSquare : Square
{
    internal override bool Walkable() => false;

    internal override void OnMouseDown()
    {
        if (board.IsSelectable(gridPosX, gridPosY))
        {
            board.MovePlayer(gridPosX, gridPosY);
            //CombatSystem.enemies = Board.GetRandomList();
            SceneManager.LoadScene("Combat");
        }
    }

    internal override SquareType Type() => SquareType.Combat;
}
