using System;
using System.Collections.Generic;

internal abstract class Face
{
    protected readonly Unit unit;
    internal Enemy enemyTarget = null;
    internal Adventurer adventurerTarget = null;
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

    internal bool HasAllTargetsSelected()
    {
        bool AdventurerSelected = adventurerTarget != null || AdventurersCount != TargetsCount.One;
        bool EnemySelected = enemyTarget != null || EnemiesCount != TargetsCount.One;

        return AdventurerSelected && EnemySelected;
    }
}