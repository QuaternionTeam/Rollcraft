using System.Collections.Generic;
using System.Linq;

internal class ResolveEnemiesDiceState : CombatSystemState
{
    public ResolveEnemiesDiceState(CombatSystem context) : base(context) { }

    internal override void Enter()
    {
        List<Die> enemiesDice = CombatData.Enemies.Select(enemy => enemy.Die).ToList();

        foreach(Die die in enemiesDice)
        {
            die.Resolve();

            if(CombatData.Adventurers.Count > 0)
                continue;
                
            context.ChangeState(Combat.Lose);
            break;
        }

        if(CombatData.Adventurers.Count == 0)
            return;

        context.ChangeState(Combat.EnemiesRoll);
    }
}
