using System.Linq;

internal class MageViolet2 : Face
{
    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.One;

    public MageViolet2(Unit unit) : base(unit) { }

    internal override void ApplyEffect() 
    {
        base.ApplyEffect();
        int damage = 1;
        int healing = 1;

        if(unit.quickness == Quickness.Fast)
            healing += 2;

        if(unit.quickness == Quickness.Slow)
            damage += 2;

        enemies.First().RecieveAttack(damage);
        adventurers.First().RecieveHealing(healing);
    }
}