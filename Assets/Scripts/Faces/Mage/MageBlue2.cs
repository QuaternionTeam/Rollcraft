using System.Linq;

internal class MageBlue2 : Face
{
    public MageBlue2(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    internal override string EffectString => "2 DMG\nFast: -1 DMG\nSlow: +1 DMG";

    [Fast]
    internal void FastAttack() => Attack(enemyTarget, 1);

    [Mid]
    internal void MidAttack() => Attack(enemyTarget, 2);

    [Slow]
    internal void SlowAttack() => Attack(enemyTarget, 3);
}