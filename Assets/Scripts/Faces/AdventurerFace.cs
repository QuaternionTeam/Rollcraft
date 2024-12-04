using System;
using UnityEngine;

internal class AdventurerFace: Face
{
    [SerializeField] private SkillStrategy OnLandSkill;
    [SerializeField] private SkillStrategy FastSkill;
    [SerializeField] private SkillStrategy NeutralSkill;
    [SerializeField] private SkillStrategy SlowSkill;

    [SerializeField] internal Class Class;

    private Quickness SkillQuickness => ((Adventurer) die.Owner).Quickness;
    internal override SelectionStrategy Target => SkillQuickness switch
        {
            Quickness.Fast => FastSkill.Target,
            Quickness.Neutral => NeutralSkill.Target,
            Quickness.Slow => SlowSkill.Target,
            _ => SelectionStrategy.NoTarget,
        };

    internal void SetEnemyTarget(Enemy enemy)
    {
        //OnLandSkill.SetEnemyTarget(enemy);
        NeutralSkill.SetEnemyTarget(enemy);
        FastSkill.SetEnemyTarget(enemy);
        SlowSkill.SetEnemyTarget(enemy);
    }
    internal void SetAdventurerTarget(Adventurer adventurer)
    {
        //OnLandSkill.SetAdventurerTarget(adventurer);
        NeutralSkill.SetAdventurerTarget(adventurer);
        FastSkill.SetAdventurerTarget(adventurer);
        SlowSkill.SetAdventurerTarget(adventurer);
    }

    internal override void OnLand()
    {
        SetAdventurerTarget(null);
        SetEnemyTarget(null);

        OnLandSkill.Resolve();
    }

     internal override void Resolve()
    {
        Action Skill = SkillQuickness switch
        {
            Quickness.Fast => FastSkill.Resolve,
            Quickness.Neutral => NeutralSkill.Resolve,
            Quickness.Slow => SlowSkill.Resolve,
            _ => () => {}
        };

        Skill();
    }
}
