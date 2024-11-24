internal class ArcherBlue3 : Face
{
    public ArcherBlue3(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.All;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    internal override string EffectString => "1 DMG (All)";
    
    [Neutral]
    internal void NeutralAttack() => AttackAllEnemies(1);
}