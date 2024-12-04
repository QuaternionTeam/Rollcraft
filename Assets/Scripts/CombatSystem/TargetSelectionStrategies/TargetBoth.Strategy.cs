internal class TargetBoth : TargetSelectionStrategy
{
    private readonly TargetEnemy TargeyEnemy;
    private readonly TargetAdventurer TargetAdventurer;

    internal TargetBoth(CombatSystem context) : base(context) 
    { 
        TargeyEnemy = new(context);
        TargetAdventurer = new(context);
    }

    internal override bool ReadyToConfirm => 
        TargeyEnemy.ReadyToConfirm && TargetAdventurer.ReadyToConfirm;

    internal override void Enter()
    {
        TargeyEnemy.Enter();
        TargetAdventurer.Enter();
    }

    internal override void Exit()
    {
        TargeyEnemy.Exit();
        TargetAdventurer.Exit();
    }

    internal override void SetTarget(AdventurerFace face)
    {
        TargeyEnemy.SetTarget(face);
        TargetAdventurer.SetTarget(face);
    }

    internal override void Update()
    {
        TargeyEnemy.Update();
        TargetAdventurer.Update();
    }
}
