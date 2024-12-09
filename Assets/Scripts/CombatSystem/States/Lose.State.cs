using UnityEngine;

internal class LoseState : CombatSystemState
{
    public LoseState(CombatSystem context) : base(context) { }

    internal override void Enter()
    {
        base.Enter();

        //Lose
        Debug.Log("You Lose");
    }
}