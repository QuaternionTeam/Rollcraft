using System.Linq;

internal class WarriorBlue2 : Face
{
    internal override TargetsCount EnemiesCount => 
        unit.quickness == Quickness.Slow ? TargetsCount.One : TargetsCount.None;

    internal override TargetsCount AdventurersCount => 
         unit.quickness == Quickness.Fast ? TargetsCount.One : TargetsCount.None;

    public WarriorBlue2(Unit unit) : base(unit) { }

    internal override void ApplyEffect() 
    {
        base.ApplyEffect();

        if(unit.quickness == Quickness.Fast)
            enemies.First().RecieveShield(2);

        if(unit.quickness == Quickness.Slow)
            enemies.First().RecieveAttack(2);
    }
}