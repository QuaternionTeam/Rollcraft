internal class NoTarget : TargetSelectionStrategy
{
    internal override bool ReadyToConfirm => true;
    internal override void Update() { }
}