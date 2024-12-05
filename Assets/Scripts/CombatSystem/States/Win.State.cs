using UnityEngine;

internal class WinState : CombatSystemState
{
    public WinState(CombatSystem context) : base(context) { }

    internal override void Enter()
    {
        base.Enter();

        //WIN
        Debug.Log("You Win");
    }
}