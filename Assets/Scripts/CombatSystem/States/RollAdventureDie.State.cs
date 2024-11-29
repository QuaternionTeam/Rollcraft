using UnityEngine;

internal class RollAdventureDieState : CombatSystemState
{
    private readonly float secondsToWaitBeforeChangeState = 2f;
    private float timerSeconds = 0f;

    internal RollAdventureDieState(CombatSystem context) : base(context) { }

    internal override void Enter()
    {
        base.Enter();

        CombatData.chosen.RollDie();
    }

     internal override void Update()
    {
        base.Update();

        timerSeconds += Time.deltaTime;

        if (timerSeconds < secondsToWaitBeforeChangeState)
            return;

        context.ChangeState(Combat.TargetSelection);    
    }
}
