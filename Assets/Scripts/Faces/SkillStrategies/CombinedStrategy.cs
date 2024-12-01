using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCombinedtrategy", menuName = "Skills/Combined")]
internal class CombinedStrategy : SkillStrategy
{
    [SerializeField] private SkillStrategy FirstSkill;
    [SerializeField] private SkillStrategy SecondSkill;

    internal override void Resolve()
    {
        FirstSkill.Resolve();
        SecondSkill.Resolve();
    }

    internal override void SetEnemyTarget(Enemy enemy)
    {
        base.SetEnemyTarget(enemy);

        FirstSkill.SetEnemyTarget(enemy);
        SecondSkill.SetEnemyTarget(enemy);
    }

    internal override void SetAdventurerTarget(Adventurer adventurer)
    {
        base.SetAdventurerTarget(adventurer);
        
        FirstSkill.SetAdventurerTarget(adventurer);
        SecondSkill.SetAdventurerTarget(adventurer);
    }
}