using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal static class CombatInitializationData
{
    internal static List<Enemy> enemyPrefabs;
    internal static Vector2Int gridPosition;
    internal static bool victory;
}

internal class CombatSystem: MonoBehaviour
{
    public Enemy wolf;
    public Adventurer archerPrefab;
    public Adventurer warriorPrefab;
    public Adventurer magePrefab;

    public static List<Adventurer> adventurers;
    public static List<Enemy> enemies;
    internal List<Face> enemyFaces;
    internal List<int> enemyFacesIndex;
    internal Face adventurerFace = null;

    static internal CombatSystemState State = null;

    internal void Start() 
    { 
        /*
        enemies = new()
        {
            Instantiate(enemyPrefabs[0], new Vector3(-5, 5, 0), Quaternion.identity),
            Instantiate(enemyPrefabs[1], new Vector3(0, 5.5f, 0), Quaternion.identity),
            Instantiate(enemyPrefabs[2], new Vector3(5, 5, 0), Quaternion.identity),
        };
        */
        
        enemies = new()
        {
            Instantiate(wolf, new Vector3(-5, 5, 0), Quaternion.identity),
            Instantiate(wolf, new Vector3(0, 5.5f, 0), Quaternion.identity),
            Instantiate(wolf, new Vector3(5, 5, 0), Quaternion.identity),
        };

        Instantiate(archerPrefab);
        Instantiate(warriorPrefab);
        Instantiate(magePrefab);
        
        adventurers = new()
        {
            Instantiate(archerPrefab),
            Instantiate(warriorPrefab),
            Instantiate(magePrefab),
        };

        StartCoroutine(StartCombat());
    }

    private IEnumerator StartCombat()
    {
        yield return new WaitForSeconds(1f);

        State = new EnemyRollState(this);
    }

    internal void Update() 
    {
        if(State == null)
            return;
        State.Update();
    }

    internal static void Died(Unit unit) 
    {
        if(unit is Adventurer adventurer)
            adventurers.Remove(adventurer);

        if(unit is Enemy enemy)
            enemies.Remove(enemy);
    }

    internal virtual void Reroll() 
    { 
        State.Reroll();
    }

    internal void ChangeState(CombatSystemState newState)
    {
        State = newState;
    }

}