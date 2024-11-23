using System.Linq;

internal class WarriorViolet1 : Face
{
    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    public WarriorViolet1(Unit unit) : base(unit) { }

    internal override void ApplyEffect() 
    {
        base.ApplyEffect();

        enemies.First().RecieveAttack(3);
    }
}