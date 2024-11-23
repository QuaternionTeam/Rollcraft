using System.Linq;

internal class MageBlue2 : Face
{
    public MageBlue2(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    internal override void ApplyEffect() 
    {
        base.ApplyEffect();
        int damage = 2;

        if(unit.quickness == Quickness.Fast)
            damage -= 1;

        if(unit.quickness == Quickness.Slow)
            damage +=1;

        enemies.First().RecieveAttack(damage);
    }
}