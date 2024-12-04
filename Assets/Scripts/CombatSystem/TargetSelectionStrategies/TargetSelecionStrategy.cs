internal abstract class TargetSelectionStrategy 
{ 
    protected readonly CombatSystem context;

    internal TargetSelectionStrategy(CombatSystem context)
    {
        this.context = context;
    }
    internal abstract bool ReadyToConfirm { get; }
    internal abstract void Update();
    internal abstract void Enter();
    internal abstract void Exit();
    internal abstract void SetTarget(AdventurerFace face);
}
