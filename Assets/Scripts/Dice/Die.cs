using System.Collections.Generic;
using UnityEngine;

internal class Die: MonoBehaviour
{
    internal Unit Owner;
    [SerializeField] private Face Face1;
    [SerializeField] private Face Face2;
    [SerializeField] private Face Face3;
    [SerializeField] private Face Face4;
    [SerializeField] private Face Face5;
    [SerializeField] private Face Face6;
    internal Face[] Faces;
    internal Face FaceUp;
    protected Dictionary<DieStates, DieState> states;
    protected DieState state;
    internal Transform transformComponent;

    internal virtual void Awake()
    {
        //Debug.Log("Die Awoken");
        transformComponent = transform;

        states = new() 
        { 
            { DieStates.Static, new DieStaticInitial(this) },
            { DieStates.Rolling, new DieRollingState(this) },
            { DieStates.Landing, new DieLandingState(this) },
        };
        
        state = states[DieStates.Static];

        Faces = new[]
        {
            Instantiate(Face1, transform.position + new Vector3(0f, 0f, -1.2f), Quaternion.identity, transform),
            Instantiate(Face2, transform.position + new Vector3(1.2f, 0f, 0f), Quaternion.Euler(0f, -90f, 0f), transform),
            Instantiate(Face3, transform.position + new Vector3(0f, 1.2f, 0f), Quaternion.Euler(90f, 0f, 0f), transform),
            Instantiate(Face4, transform.position + new Vector3(0f, -1.2f, 0f), Quaternion.Euler(-90f, 0f, 0f), transform),
            Instantiate(Face5, transform.position + new Vector3(-1.2f, 0f, 0f), Quaternion.Euler(0f, 90f, 0f), transform),
            Instantiate(Face6, transform.position + new Vector3(0f, 0f, 1.2f), Quaternion.Euler(0f, 0f, 0f), transform),
        };

        foreach(Face face in Faces)
            face.SetDie(this);
    }

    internal void SetOwner(Unit unit)
    {
        Owner = unit;
    }

    internal void Update()
    {
        state.Update();
    }

    internal void Roll()
    {
        state.Roll();
    }

    internal void Resolve()
    {
        FaceUp.Resolve();
    }

    internal void ChangeState(DieStates newState)
    {
        state.Exit();
        state = states[newState];
        state.Enter();
    }
}
