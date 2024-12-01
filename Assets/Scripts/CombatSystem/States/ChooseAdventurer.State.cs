using UnityEngine;

internal class ChooseAdveturersState : CombatSystemState
{

    internal ChooseAdveturersState(CombatSystem context) : base(context) { }

    internal override void Enter()
    {
        base.Enter();

        //Enable EndTurn Button

        foreach (Adventurer adventurer in CombatData.Adventurers)
            if(adventurer.HasDie) 
                adventurer.TurnGlowOn();
    }

    internal override void Exit()
    {
        base.Exit();

        //Disable EndTurn Button
        foreach (Adventurer adventurer in CombatData.Adventurers)
                adventurer.TurnGlowOff();
    }

    internal override void Update()
    {
        base.Update();

        HandleAdventurerSelection();

        //TODO: If End Turn Button Pressed
        if(Input.GetKeyDown(KeyCode.Space))
            context.ChangeState(Combat.ResolveEnemiesDice);  
    }

    internal override void EndTurn()
    {
        base.EndTurn();

        foreach (Adventurer adventurer in CombatData.Adventurers)
            adventurer.TurnGlowOff();

        context.ChangeState(Combat.ResolveEnemiesDice);
    }

    private void HandleAdventurerSelection()
    {
        Adventurer clickedAdventurer = Selector.GetUnitOnClick<Adventurer>(context.adventurersLayer);
        
        if (!clickedAdventurer)
            return;

        clickedAdventurer.HasDie = false;
        CombatData.Chosen = clickedAdventurer;
        context.ChangeState(Combat.AdventurerRoll);
    }
}
