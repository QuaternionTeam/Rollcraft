using System.Collections.Generic;
using UnityEngine;

internal class TargetSeleccionState : CombatSystemState
{
    private readonly Dictionary<SelectionStrategy, TargetSelectionStrategy> selectionStrategies;
    private TargetSelectionStrategy selectionStrategy;

    internal TargetSeleccionState(CombatSystem context) : base(context) 
    { 
        selectionStrategies = new() 
        {
            { SelectionStrategy.NoTarget, new NoTarget() },
        };
    }

    internal override void Enter()
    {
        base.Enter();

        //Throws some null exception from the second time it enters and on
        //It doesnt really affect the system
        SelectionStrategy strategy = CombatData.chosen.Die.faceUp.Target;
        selectionStrategy = selectionStrategies[strategy];

        //TODO: Enable Reroll Button
        //TODO: Enable Confirm Button
    }

    internal override void Exit()
    {
        base.Exit();

        //TODO: Disable Reroll Button
        //TODO: Disable Confirm Button
    }

    internal override void Update()
    {
        base.Update();

        selectionStrategy.Update();

        //TODO: If Reroll Button Pressed && Has Rerolls
        if(GameData.Instance.RerrollsCount() == -3)
        {
            GameData.Instance.RemoveRerroll();
            context.ChangeState(Combat.AdventurerRoll);
        }
            
        //TODO: If Confirm Button Pressed
        if(selectionStrategy.ReadyToConfirm && Input.GetKeyDown(KeyCode.Space))
            context.ChangeState(Combat.ResolveAdventurerDie);
    }
}
