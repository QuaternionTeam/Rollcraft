internal class WarriorBlue1 : Face
{
    internal override TargetsCount EnemiesCount => 
        unit.quickness == Quickness.Fast ? TargetsCount.One : TargetsCount.None;

    internal override TargetsCount AdventurersCount => 
         unit.quickness == Quickness.Slow ? TargetsCount.One : TargetsCount.None;

    internal override string EffectString => "\nFast: 2 DMG\nSlow: 2 Shield";

    public WarriorBlue1(Unit unit) : base(unit) { }

    [Fast]
    internal void FastAttack() => Attack(enemyTarget, 2);

    [Slow]
    internal void SlowAttack() => Protect(adventurerTarget, 2);
}