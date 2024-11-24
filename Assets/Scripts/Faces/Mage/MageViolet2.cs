internal class MageViolet2 : Face
{
    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.One;

    public MageViolet2(Unit unit) : base(unit) { }

    internal override string EffectString => "1 DMG & 1 Heal\nFast: +2 Heal\nSlow: +2 DMG";

    [Fast]
    internal void FastAttack() => Attack(enemyTarget, 1);

    [Fast]
    internal void FastHeal() => Heal(adventurerTarget, 3);

    [Mid]
    internal void MidAttack() => Attack(enemyTarget, 1);

    [Mid]
    internal void MidHeal() => Heal(adventurerTarget, 1);

    [Slow]
    internal void SlowAttack() => Attack(enemyTarget, 3);

    [Slow]
    internal void SlowHeal() => Heal(adventurerTarget, 1);
}