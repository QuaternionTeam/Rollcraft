using UnityEngine;

internal class TargetSeleccionState : CombatSystemState
{
    private readonly TargetStrategies Strategies;
    private TargetSelectionStrategy selectionStrategy;

    internal TargetSeleccionState(CombatSystem context) : base(context) 
    { 
        Strategies = new(context);
    }

    internal override void Enter()
    {
        base.Enter();

        //Throws some null exception from the second time it enters and on
        //It doesnt really affected the system so far
        SelectionStrategy strategy = CombatData.Chosen.Die.FaceUp.Target;
        selectionStrategy = Strategies.GetStrategy(strategy);

        selectionStrategy.Enter();

        //TODO: Enable Reroll Button
        //TODO: Enable Confirm Button
    }

    internal override void Exit()
    {
        base.Exit();

        selectionStrategy.Exit();

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
        {
            Face faceToResolve = CombatData.Chosen.Die.FaceUp;
            selectionStrategy.SetTarget(faceToResolve);
            context.ChangeState(Combat.ResolveAdventurerDie);
        }
            
    }
}
