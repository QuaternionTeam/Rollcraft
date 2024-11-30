internal class NoTarget : TargetSelectionStrategy
{
    public NoTarget(CombatSystem context) : base(context) { }
    internal override bool ReadyToConfirm => true;
    internal override void Update() { }

}