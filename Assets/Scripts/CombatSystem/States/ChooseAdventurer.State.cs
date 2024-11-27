internal class ChooseAdveturersState : CombatSystemState
{
    internal ChooseAdveturersState(CombatSystem context) : base(context) 
    { 
        //Enable EndTurn Button
    }

    internal override void EndTurn()
    {
        //Disnable EndTurn Button
        context.ChangeState(new ResolveEnemiesFacesState(context));
    }
}