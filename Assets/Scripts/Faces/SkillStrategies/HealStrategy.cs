using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewHealStrategy", menuName = "Skills/Heal")]
internal class HealStrategy : SkillStrategy
{
    [SerializeField] private int healing;
    
    internal override void Resolve()
    {
        Debug.Log("I Healed.");
        
        Action Heal = Target switch
        {
            SelectionStrategy.Enemy => HealEnemy,
            SelectionStrategy.RandomEnemy => HealRandomEnemy,
            SelectionStrategy.AllEnemy => HealAllEnemy,
            SelectionStrategy.Adventurer => HealAdventurer,
            SelectionStrategy.RandomAdventurer => HealRandomAdventurer,
            SelectionStrategy.AllAdventurer => HealAllAdventurer,
            //SelectionStrategy.Both => HealBoth,
            _ => () => {}
        };

        Heal();
    }

    internal void HealEnemy()
    {
        EnemyTarget.Heal(healing);
    }

    internal void HealRandomEnemy()
    {
        CombatData.RandomEnemy.Heal(healing);
    }

    internal void HealAllEnemy()
    {
        foreach(Enemy enemy in CombatData.Enemies)
            enemy.Heal(healing);
    }

    internal void HealAdventurer()
    {
        AdventurerTarget.Heal(healing);
    }

    internal void HealRandomAdventurer()
    {
        CombatData.RandomAdventurer.Heal(healing);
    }

    internal void HealAllAdventurer()
    {
        foreach(Adventurer adventurer in CombatData.Adventurers)
            adventurer.Heal(healing);
    }

    internal void HealBoth()
    {

    }

}