using System.Collections.Generic;
using System.Linq;

internal class ResolveEnemiesDiceState : CombatSystemState
{
    public ResolveEnemiesDiceState(CombatSystem context) : base(context) { }

    internal override void Enter()
    {
        List<Die> enemiesDice = CombatData.enemies.Select(enemy => enemy.Die).ToList();

        foreach(Die die in enemiesDice)
        {
            die.Resolve();

            if(CombatData.adventurers.Count > 0)
                continue;
                
            context.ChangeState(Combat.Lose);
            break;
        }

        if(CombatData.adventurers.Count == 0)
            return;

        context.ChangeState(Combat.EnemiesRoll);
    }
}
