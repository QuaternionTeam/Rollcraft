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
    internal override string EffectText => SkillQuickness switch
        {
            Quickness.Fast => FastSkill.EffectText,
            Quickness.Neutral => NeutralSkill.EffectText,
            Quickness.Slow => SlowSkill.EffectText,
            _ => "None",
        };

    
    internal string FullEffectText => 
    "On Land: " + OnLandSkill.EffectText + "\n"+
    NeutralSkill.EffectText + "\n"+
    "Fast: " + FastSkill.EffectText + "\n"+
    "Slow: " + SlowSkill.EffectText; 

    internal void Awake()
    {
        Color color = Class switch
        {
            Class.Archer => new(1.0f, 0.7f, 0.3f),
            Class.Mage => new(0.5f, 0.7f, 1.0f),
            Class.Warrior => new(0.7f, 0.7f, 0.7f),
            _ => Color.white,
        };

        SpriteRenderer SpriteRenderer = GetComponent<SpriteRenderer>();
        SpriteRenderer.color = color;
        
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
