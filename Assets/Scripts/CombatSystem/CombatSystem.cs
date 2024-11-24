using System.Collections.Generic;
using UnityEngine;

internal class CombatSystem: MonoBehaviour
{
    internal static List<Adventurer> adventurers;
    internal static List<Enemy> enemies;
    internal List<Face> enemyFaces;
    internal Face adventurerFace = null;

    static internal CombatSystemState State;

    internal void Start() 
    { 
        State = new EnemyRollState(this);
        Instantiate(enemies[0], new Vector3(-1, 2, 0), Quaternion.identity);
        Instantiate(enemies[0], new Vector3(0, 2.5f, 0), Quaternion.identity);
        Instantiate(enemies[0], new Vector3(1, 2, 0), Quaternion.identity);
    }

    internal void Update() 
    {
        State.Update();
    }

    internal virtual void Reroll() 
    { 
        State.Reroll();
    }

    static internal void HasBeenClicked(Unit unit) 
    { 
        State.HasBeenClicked(unit);
    }

    internal void ChangeState(CombatSystemState newState)
    {
        State = newState;
    }

}