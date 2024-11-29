internal class ResolveAdventurerDieState : CombatSystemState
{
    public ResolveAdventurerDieState(CombatSystem context) : base(context) { }

    internal override void Enter()
    {
        base.Enter();

        CombatData.chosen.ResolveDie();

        if(CombatData.enemies.Count == 0)
            context.ChangeState(Combat.Win); 
        else
            context.ChangeState(Combat.ChooseAdventurer);  
    }
}
