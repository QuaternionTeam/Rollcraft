using System.Linq;

internal class ArcherViolet1 : Face
{
    public ArcherViolet1(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.All;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    internal override void ApplyEffect() 
    {
        base.ApplyEffect();

        enemies.First().RecieveAttack(1);
        unit.dice.Roll();
    }
}