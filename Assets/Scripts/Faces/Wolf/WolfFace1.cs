
internal class WolfFace1 : Face
{
    public WolfFace1(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.None;

    internal override TargetsCount AdventurersCount => TargetsCount.One;

    internal override string EffectString => "2 DMG";

    [Neutral]
    internal void NeutraltAttack() => Attack(adventurerTarget, 2);

}