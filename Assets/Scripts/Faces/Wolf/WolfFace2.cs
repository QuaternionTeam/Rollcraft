
internal class WolfFace2 : Face
{
    public WolfFace2(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.None;

    internal override TargetsCount AdventurersCount => TargetsCount.One;

    internal override string EffectString => "1 DMG (All)";

    [Neutral]
    internal void NeutraltAttack() => AttackAllAdventurers(1);

}