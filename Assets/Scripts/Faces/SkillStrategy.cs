using UnityEngine;

internal abstract class SkillStrategy: ScriptableObject
{
    protected Enemy EnemyTarget;
    protected Adventurer AdventurerTarget;

    [SerializeField] internal SelectionStrategy Target;

    //[SerializeField] internal int damage;
    //[SerializeField] internal int healing;
    //[SerializeField] internal int shielding;

    internal void SetEnemyTarget(Enemy enemy)
    {
        EnemyTarget = enemy;
    }
    internal void SetAdventurerTarget(Adventurer adventurer)
    {
        AdventurerTarget = adventurer;
    }

    internal abstract void Resolve();
}
