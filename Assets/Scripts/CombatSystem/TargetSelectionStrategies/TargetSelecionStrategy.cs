internal abstract class TargetSelectionStrategy 
{ 
    internal abstract bool ReadyToConfirm { get; }
    internal abstract void Update();
}