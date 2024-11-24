internal class ChooseAdveturersState : CombatSystemState
{
    internal ChooseAdveturersState(CombatSystem context) : base(context) 
    { 
        //Enable EndTurn Button
    }

    internal override void HasBeenClicked(Unit unit)
    {
        base.HasBeenClicked(unit);
        
        if(unit is not Adventurer adventurer)
            return;

        //Disnable EndTurn Button
        context.ChangeState(new RollAdventureDiceState(context, adventurer));
    }

    internal override void EndTurn()
    {
        //Disnable EndTurn Button
        context.ChangeState(new ResolveEnemiesFacesState(context));
    }
}