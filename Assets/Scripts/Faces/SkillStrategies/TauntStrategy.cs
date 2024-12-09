using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTauntSkill", menuName = "Skills/Taunt")]
internal class TauntStrategy : SkillStrategy
{
    internal override void Resolve()
    { 
        Action Attack = Target switch
        {
            //SelectionStrategy.Enemy => AttackEnemy,
            //SelectionStrategy.RandomEnemy => AttackRandomEnemy,
            //SelectionStrategy.AllEnemy => AttackAllEnemy,
            //SelectionStrategy.Adventurer => AttackAdventurer,
            SelectionStrategy.RandomAdventurer => TauntRandomAdventurer,
            SelectionStrategy.AllAdventurer => TauntAllAdventurer,
            //SelectionStrategy.Both => AttackBoth,
            _ => () => {}
        };

        Attack();
    }
    internal void TauntRandomAdventurer()
    {
        CombatData.RandomAdventurer.isTaunted = true;
    }

    internal void TauntAllAdventurer()
    {
        foreach(Adventurer adventurer in CombatData.Adventurers)
            adventurer.isTaunted = true;
    }
}
