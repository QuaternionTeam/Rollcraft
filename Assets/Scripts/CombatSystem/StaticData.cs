using System.Collections.Generic;
using UnityEngine;

internal static class CombatInitializationData
{
    internal static List<Enemy> enemyPrefabs;
    internal static Vector2Int gridPosition;
    internal static bool victory;
}

internal static class CombatData
{
    internal static CombatSystem system;
    internal static List<Adventurer> adventurers;
    internal static List<Enemy> enemies;

    internal static Adventurer chosen;

    internal static void UnitDied(Unit unit) 
    {
        if(unit is Adventurer adventurer)
            adventurers.Remove(adventurer);

        if(unit is Enemy enemy)
            enemies.Remove(enemy);
    }
}