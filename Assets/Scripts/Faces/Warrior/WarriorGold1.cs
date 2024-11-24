using System.Linq;

internal class WarriorGold1 : Face
{
    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.None;
    
    public WarriorGold1(Unit unit) : base(unit) { }

    internal override string EffectString => "5 DMG";

    [Neutral]
    internal void NeutralAttack() => Attack(enemyTarget, 5);
}