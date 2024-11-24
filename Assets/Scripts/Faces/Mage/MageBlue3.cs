using System.Linq;

internal class MageBlue3 : Face
{
    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    internal override string EffectString => "2 Heal";

    public MageBlue3(Unit unit) : base(unit) { }

    [Neutral]
    internal void Healing() => Heal(adventurerTarget, 2);
}