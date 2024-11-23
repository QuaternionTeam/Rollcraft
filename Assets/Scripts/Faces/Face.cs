using System.Collections.Generic;

internal abstract class Face
{
    protected readonly Unit unit;
    internal List<Enemy> enemies = null;
    internal List<Adventurer> adventurers = null;
    internal abstract TargetsCount EnemiesCount { get; }
    internal abstract TargetsCount AdventurersCount { get; }

    internal Face(Unit unit)
    {
        this.unit = unit;
    }

    internal virtual void OnLand() { }

    internal virtual void ApplyEffect() { }

    internal void SetTargets(List<Enemy> enemies, List<Adventurer> adventurers)
    {
        this.enemies = enemies;
        this.adventurers = adventurers;
    }

}