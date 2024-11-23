using System.Linq;

internal class MageViolet1 : Face
{
    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    public MageViolet1(Unit unit) : base(unit) { }

    internal override void ApplyEffect() 
    {
        base.ApplyEffect();
        int damage = 4;

        if(unit.quickness == Quickness.Fast)
            damage -= 2;

        if(unit.quickness == Quickness.Slow)
            damage += 2;

        enemies.First().RecieveAttack(damage);
    }
}