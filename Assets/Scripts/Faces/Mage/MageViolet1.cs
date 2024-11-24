using System.Linq;

internal class MageViolet1 : Face
{
    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    public MageViolet1(Unit unit) : base(unit) { }

    internal override string EffectString => "4 DMG\nFast: -2 DMG\nSlow: +2 DMG";

    [Fast]
    internal void FastAttack() => Attack(enemyTarget, 2);

    [Mid]
    internal void MidAttack() => Attack(enemyTarget, 4);

    [Slow]
    internal void SlowAttack() => Attack(enemyTarget, 6);
}