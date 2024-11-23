using System.Linq;

internal class ArcherBlue1 : Face
{
    public ArcherBlue1(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    internal override void ApplyEffect() 
    {
        base.ApplyEffect();

        enemies.First().RecieveAttack(1);

        enemies.First().RecieveAttack(1);
    }
}