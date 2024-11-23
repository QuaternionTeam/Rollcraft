using System.Linq;

internal class WarriorViolet2 : Face
{
    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.One;

    public WarriorViolet2(Unit unit) : base(unit) { }

    internal override void ApplyEffect() 
    {
        base.ApplyEffect();

        enemies.First().RecieveAttack(2);
        adventurers.First().RecieveShield(2);
    }
}