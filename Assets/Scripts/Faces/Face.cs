using System;
using UnityEngine;

internal class Face: MonoBehaviour
{
    //internal int diceIndex;
    //[SerializeField] private Sprite Sprite;

    private Die die;

    internal SelectionStrategy Target = SelectionStrategy.NoTarget;

    [SerializeField] private SkillStrategy OnLandSkill;
    [SerializeField] private SkillStrategy FastSkill;
    [SerializeField] private SkillStrategy NeutralSkill;
    [SerializeField] private SkillStrategy SlowSkill;

    internal void SetDie(Die die)
    {
        this.die = die;
    }

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

    internal void OnLand()
    {
        SetAdventurerTarget(null);
        SetEnemyTarget(null);

        OnLandSkill.Resolve();
    }

    internal void Resolve()
    {
        Quickness Quickness = ((Adventurer) die.Owner).Quickness;

        Action Skill = Quickness switch
        {
            Quickness.Fast => FastSkill.Resolve,
            Quickness.Neutral => NeutralSkill.Resolve,
            Quickness.Slow => SlowSkill.Resolve,
            _ => () => {}
        };

        Skill();
    }
}
