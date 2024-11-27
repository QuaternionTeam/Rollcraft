using System.Collections.Generic;
using UnityEngine;

internal class Die: MonoBehaviour
{
    internal Face[] faces;
    protected Dictionary<DieStates, DieState> states;
    protected DieState state;

    internal Transform transformComponent;

    internal virtual void Awake()
    {
        transformComponent = transform;

        states = new() 
        { 
            { DieStates.Static, new DieStaticInitial(this) },
            { DieStates.Rolling, new DieRollingState(this) },
            { DieStates.Landing, new DieLandingState(this) },
        };
        
        state = states[DieStates.Static];
    }

    internal void Update()
    {
        state.Update();
    }

    internal void Roll()
    {
        state.Roll();
    }

    internal void ChangeState(DieStates newState)
    {
        state.Exit();
        state = states[newState];
        state.Enter();
    }
}
