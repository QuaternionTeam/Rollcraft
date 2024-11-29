using UnityEngine;

internal class EnemiesRollState : CombatSystemState
{
    private readonly float secondsToWaitBeforeChangeState = 2f;
    private float timerSeconds = 0f;

    public EnemiesRollState(CombatSystem context) : base(context) { }

    internal override void Enter()
    {
        base.Enter();
        
        RollEnemiesDice();
        
        SetAdventurersDice();

        timerSeconds = 0f;
    }

    internal override void Update()
    {
        base.Update();

        timerSeconds += Time.deltaTime;

        if (timerSeconds < secondsToWaitBeforeChangeState)
            return;

        context.ChangeState(Combat.ChooseAdventurer);     
    }

    private void SetAdventurersDice()
    {
        foreach(Adventurer adventurer in CombatData.adventurers)
            adventurer.HasDie = true;
    }

    private void RollEnemiesDice()
    {
        foreach(Enemy enemy in CombatData.enemies)
            enemy.Die.Roll();
    }
}
