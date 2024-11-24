internal class ArcherBlue2 : Face
{
    public ArcherBlue2(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    [OnLand]
    internal void OnLandAttack() => Attack(enemyTarget, 1);

    [Neutral]
    internal void NeutralAttack() => Attack(enemyTarget, 1);
}