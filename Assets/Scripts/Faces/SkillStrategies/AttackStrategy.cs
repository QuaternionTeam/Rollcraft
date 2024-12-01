using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAttackSkill", menuName = "Skills/Attack")]
internal class AttackStrategy : SkillStrategy
{
    [SerializeField] private int damage;
    
    internal override void Resolve()
    {
        Debug.Log("I Attacked!");
        
        Action Attack = Target switch
        {
            SelectionStrategy.Enemy => AttackEnemy,
            SelectionStrategy.RandomEnemy => AttackRandomEnemy,
            SelectionStrategy.AllEnemy => AttackAllEnemy,
            SelectionStrategy.Adventurer => AttackAdventurer,
            SelectionStrategy.RandomAdventurer => AttackRandomAdventurer,
            SelectionStrategy.AllAdventurer => AttackAllAdventurer,
            //SelectionStrategy.Both => AttackBoth,
            _ => () => {}
        };

        Attack();
    }

    internal void AttackEnemy()
    {
        EnemyTarget.Damage(damage);
    }

    internal void AttackRandomEnemy()
    {
        CombatData.RandomEnemy.Damage(damage);
    }

    internal void AttackAllEnemy()
    {
        foreach(Enemy enemy in CombatData.Enemies)
            enemy.Damage(damage);
    }

    internal void AttackAdventurer()
    {
        AdventurerTarget.Damage(damage);
    }

    internal void AttackRandomAdventurer()
    {
        CombatData.RandomAdventurer.Damage(damage);
    }

    internal void AttackAllAdventurer()
    {
        foreach(Adventurer adventurer in CombatData.Adventurers)
            adventurer.Damage(damage);
    }

    internal void AttackBoth()
    {

    }

}