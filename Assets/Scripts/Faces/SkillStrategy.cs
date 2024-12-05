using UnityEngine;

internal abstract class SkillStrategy: ScriptableObject
{
    protected Enemy EnemyTarget;
    protected Adventurer AdventurerTarget;

    [SerializeField] internal SelectionStrategy Target;
    [SerializeField, TextArea] internal string EffectText;

    internal virtual void SetEnemyTarget(Enemy enemy)
    {
        EnemyTarget = enemy;
    }
    
    internal virtual void SetAdventurerTarget(Adventurer adventurer)
    {
        AdventurerTarget = adventurer;
    }

    internal abstract void Resolve();
}
