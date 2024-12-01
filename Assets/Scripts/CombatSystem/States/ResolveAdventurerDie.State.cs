internal class ResolveAdventurerDieState : CombatSystemState
{
    public ResolveAdventurerDieState(CombatSystem context) : base(context) { }

    internal override void Enter()
    {
        base.Enter();

        CombatData.Chosen.ResolveDie();

        if(CombatData.Enemies.Count == 0)
            context.ChangeState(Combat.Win); 
        else
            context.ChangeState(Combat.ChooseAdventurer);  
    }
}
