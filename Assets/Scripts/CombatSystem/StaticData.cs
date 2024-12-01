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
    internal static CombatSystem System;
    internal static CombatHUD Hud;
    internal static List<Adventurer> Adventurers;
    internal static List<Enemy> Enemies;
    internal static Adventurer Chosen;

    internal static Enemy RandomEnemy 
    {
        get 
        {
            int random = Random.Range(0, Enemies.Count);
            return Enemies[random]; 
        }
    }

    internal static Adventurer RandomAdventurer
    {
        get 
        {
            int random = Random.Range(0, Adventurers.Count);
            return Adventurers[random]; 
        }
    }

    internal static void UnitDied(Unit unit) 
    {
        if(unit is Adventurer adventurer)
            Adventurers.Remove(adventurer);

        if(unit is Enemy enemy)
            Enemies.Remove(enemy);
    }
}