using UnityEngine;

internal class ChooseAdveturersState : CombatSystemState
{
    private readonly Camera mainCamera;

    internal ChooseAdveturersState(CombatSystem context) : base(context) 
    { 
        mainCamera = Camera.main;
    }

    internal override void Enter()
    {
        base.Enter();

        //Enable EndTurn Button

        foreach (Adventurer adventurer in CombatData.adventurers)
            if(adventurer.HasDie) 
                adventurer.TurnGlowOn();
    }

    internal override void Exit()
    {
        base.Exit();

        //Disable EndTurn Button
        foreach (Adventurer adventurer in CombatData.adventurers)
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

        foreach (Adventurer adventurer in CombatData.adventurers)
            adventurer.TurnGlowOff();

        context.ChangeState(Combat.ResolveEnemiesDice);
    }

    private void HandleAdventurerSelection()
    {
        if (!Input.GetMouseButtonDown(0))
            return; 

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, context.adventurersLayer);

        if (!hit.collider)
            return;
        
        Adventurer clickedAdventurer = hit.collider.GetComponent<Adventurer>();

        if (!clickedAdventurer)
            return;

        clickedAdventurer.HasDie = false;
        CombatData.chosen = clickedAdventurer;
        context.ChangeState(Combat.AdventurerRoll);
    }
}
