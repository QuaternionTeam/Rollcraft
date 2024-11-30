internal abstract class TargetSelectionStrategy 
{ 
    protected readonly CombatSystem context;

    internal TargetSelectionStrategy(CombatSystem context)
    {
        this.context = context;
    }
    internal abstract bool ReadyToConfirm { get; }
    internal abstract void Update();
    internal virtual void SetTarget(Face face)  { }
}