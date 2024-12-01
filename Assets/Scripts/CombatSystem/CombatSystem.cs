using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class CombatSystem: MonoBehaviour
{
    public Enemy wolf;
    public Adventurer archerPrefab;
    public Adventurer warriorPrefab;
    public Adventurer magePrefab;

    public LayerMask adventurersLayer;
    public LayerMask enemiesLayer;

    internal List<Face> enemyFaces;
    internal List<int> enemyFacesIndex;
    internal Face adventurerFace = null;

    internal CombatSystemState State = null;
    internal Dictionary<Combat, CombatSystemState> States;

    internal void Start()
    {
        CombatData.System = this;

        States = new()
        {
            { Combat.EnemiesRoll, new EnemiesRollState(this) },
            { Combat.ChooseAdventurer, new ChooseAdveturersState(this) },
            
            { Combat.AdventurerRoll, new RollAdventureDieState(this) },
            { Combat.TargetSelection, new TargetSeleccionState(this) },
            { Combat.ResolveAdventurerDie, new ResolveAdventurerDieState(this) },
            { Combat.ResolveEnemiesDice, new ResolveEnemiesDiceState(this) },

            //{ Combat.Win, new EnemiesRollState(this) },
            //{ Combat.Lose, new EnemiesRollState(this) },
        };

        CombatData.Enemies = new()
        {
            Instantiate(wolf, new Vector3(-5, 5, 0), Quaternion.identity),
            Instantiate(wolf, new Vector3(0, 5.5f, 0), Quaternion.identity),
            Instantiate(wolf, new Vector3(5, 5, 0), Quaternion.identity),
        };
        
        CombatData.Adventurers = new()
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

        State = States[Combat.EnemiesRoll];
        State.Enter();
    }

    internal void Update() 
    {
        if(State == null)
            return;
        //Debug.Log("Estado: " + State);
        State.Update();
    }

    internal void Reroll() 
    { 
        State.Reroll();
    }

    internal void ChangeState(Combat newState)
    {
        //Debug.Log("Cambie de estado de " + State + " a " + newState);
        State.Exit();
        State = States[newState];
        State.Enter();
    }
}
