using System.Linq;

internal class EnemyRollState : CombatSystemState
{
    public EnemyRollState(CombatSystem context) : base(context)
    {
        // RollEnemyDices();

        // context.ChangeState(new ChooseAdveturersState(context));
    }

    private void RollEnemyDices()
    {
        var pivot = CombatSystem.enemies.Select(enemy => enemy.Dice.Roll()).ToList();
        context.enemyFaces = pivot.Select(tuple => tuple.Item1).ToList();
        context.enemyFacesIndex = pivot.Select(tuple => tuple.Item2).ToList();
    }
}