internal class NoTarget : TargetSelectionStrategy
{
    public NoTarget(CombatSystem context) : base(context) { }
    internal override bool ReadyToConfirm => true;

    internal override void Enter() { }
    internal override void Exit() { }
    internal override void SetTarget(Face face) { }
    internal override void Update() { }
}
