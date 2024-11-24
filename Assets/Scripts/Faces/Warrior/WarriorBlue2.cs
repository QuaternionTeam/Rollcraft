using System.Linq;

internal class WarriorBlue2 : Face
{
    internal override TargetsCount EnemiesCount => 
        unit.quickness == Quickness.Slow ? TargetsCount.One : TargetsCount.None;

    internal override TargetsCount AdventurersCount => 
         unit.quickness == Quickness.Fast ? TargetsCount.One : TargetsCount.None;

    public WarriorBlue2(Unit unit) : base(unit) { }

    internal override string EffectString => "\nFast: 2 Shield\nSlow: 2 DMG";

    [Fast]
    internal void SlowAttack() => Protect(adventurerTarget, 2);

    [Slow]
    internal void FastAttack() => Attack(enemyTarget, 2);
    
}