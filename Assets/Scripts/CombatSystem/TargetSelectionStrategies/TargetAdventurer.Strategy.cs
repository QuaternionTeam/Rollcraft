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
}