using System.Linq;

internal class WarriorViolet1 : Face
{
    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    public WarriorViolet1(Unit unit) : base(unit) { }

    internal override string EffectString => "3 DMG";

    [Neutral]
    internal void NeutralAttack() => Attack(enemyTarget, 3);
}