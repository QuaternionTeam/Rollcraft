internal abstract class CombatSystemState
{
    protected readonly CombatSystem context;

    internal CombatSystemState(CombatSystem context)
    {  
        this.context = context;
    }

    internal virtual void Update() { }
    internal virtual void Reroll() { }
    internal virtual void Confirm() { }
    internal virtual void EndTurn() { }
    internal virtual void HasBeenClicked(Unit unit) { }
    
}
