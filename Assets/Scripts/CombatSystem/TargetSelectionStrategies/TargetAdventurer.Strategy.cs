using UnityEngine;

internal class TargetAdventurer : TargetSelectionStrategy
{
    private Adventurer adventurer = null;

    public TargetAdventurer(CombatSystem context) : base(context) { }
    internal override bool ReadyToConfirm => adventurer;
    internal override void Update() 
    { 
        HandleTargetSelection();
    }

    private void HandleTargetSelection()
    {
        Adventurer clickedAdventurer = Selector.GetUnitOnClick<Adventurer>(context.adventurersLayer);
        
        if (!clickedAdventurer)
            return;

        foreach(Adventurer adventurer in CombatData.Adventurers)
            adventurer.TurnGlowOff();

        if(adventurer)
            adventurer.ResetColor();

        adventurer = clickedAdventurer;
        adventurer.ChangeColor(Color.green);
    }

    internal override void SetTarget(Face face) 
    { 
        face.SetAdventurerTarget(adventurer);
        ResetTarget();
    }

    private void ResetTarget() 
    { 
        adventurer.ResetColor();
        adventurer = null;
    }

    internal override void Enter()
    {
        foreach(Adventurer adventurer in CombatData.Adventurers)
            adventurer.TurnGlowOn();
    }

    internal override void Exit()
    {
        foreach(Adventurer adventurer in CombatData.Adventurers)
            adventurer.TurnGlowOff();
    }
}