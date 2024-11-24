using System.Collections.Generic;
using UnityEngine;

internal class CombatSystem: MonoBehaviour
{
    internal readonly List<Adventurer> adventurers;
    internal readonly List<Enemy> enemies;
    internal List<Face> enemyFaces;
    internal Face adventurerFace = null;

    internal CombatSystemState State;

    internal void Awake() 
    { 
        State = new EnemyRollState(this);
    }

    internal void Update() 
    {
        State.Update();
    }

    internal virtual void Reroll() 
    { 
        State.Reroll();
    }

    internal void HasBeenClicked(Unit unit) 
    { 
        State.HasBeenClicked(unit);
    }

    internal void ChangeState(CombatSystemState newState)
    {
        State = newState;
    }

}