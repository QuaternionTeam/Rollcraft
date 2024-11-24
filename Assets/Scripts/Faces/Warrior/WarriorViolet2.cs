using System.Linq;

internal class WarriorViolet2 : Face
{
    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.One;

    public WarriorViolet2(Unit unit) : base(unit) { }

    internal override string EffectString => "2 DMG & 2 Shield";

    [Neutral]
    internal void NeutralAttack() => Attack(enemyTarget, 2);

    [Neutral]
    internal void NeutralProtect() => Protect(adventurerTarget, 2);
}