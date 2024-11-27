using System.Linq;
using UnityEngine;

internal class EnemyRollState : CombatSystemState
{
    public EnemyRollState(CombatSystem context) : base(context)
    {
        RollEnemyDices();
        
        //context.ChangeState(new ChooseAdveturersState(context));
    }

    private void RollEnemyDices()
    {
        //Debug.Log("Enemies " + CombatSystem.enemies);
        //Debug.Log("Enemies Count " + CombatSystem.enemies.Count);
        foreach(Enemy enemy in CombatSystem.enemies)
            enemy.Die.Roll();
        /*
        var pivot = CombatSystem.enemies.Select(enemy => enemy.Die.Roll()).ToList();
        context.enemyFaces = pivot.Select(tuple => tuple.Item1).ToList();
        context.enemyFacesIndex = pivot.Select(tuple => tuple.Item2).ToList();
        */
    }
}