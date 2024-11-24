using System.Linq;

internal class MageBlue1 : Face
{
    public MageBlue1(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    internal override string EffectString => "1 DMG & Apply Shocked";

    [Neutral]
    internal void NeutralAttack() => Attack(enemyTarget, 1);

    [Neutral]
    internal void Shock() => Apply(enemyTarget, new ShockedStatus());

}