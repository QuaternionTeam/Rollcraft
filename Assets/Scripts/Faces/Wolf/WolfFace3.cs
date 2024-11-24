
internal class WolfFace3 : Face
{
    public WolfFace3(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.None;

    internal override TargetsCount AdventurersCount => TargetsCount.One;

    internal override string EffectString => "4 DMG";

    [Neutral]
    internal void NeutraltAttack() => Attack(adventurerTarget, 2);

}