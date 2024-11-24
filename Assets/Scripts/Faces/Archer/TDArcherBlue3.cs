internal class ArcherBlue3 : Face
{
    public ArcherBlue3(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.All;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    [Neutral]
    internal void NeutralAttack() => Attack(enemyTarget, 1);
    //TODO ENEMYTARGET -> AllEnemies
}