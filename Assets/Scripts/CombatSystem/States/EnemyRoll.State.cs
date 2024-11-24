using System.Linq;

internal class EnemyRollState : CombatSystemState
{
    public EnemyRollState(CombatSystem context) : base(context)
    {
        RollEnemyDices();

        context.ChangeState(new ChooseAdveturersState(context));
    }

    private void RollEnemyDices()
    {
        context.enemyFaces = CombatSystem.enemies.Select(enemy => enemy.Dice.Roll()).ToList();
    }
}