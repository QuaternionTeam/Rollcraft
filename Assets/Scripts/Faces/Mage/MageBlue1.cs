using System.Linq;

internal class MageBlue1 : Face
{
    public MageBlue1(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    internal override void OnLand()
    {
        base.OnLand();
    }

    internal override void ApplyEffect() 
    {
        base.ApplyEffect();

        enemies.First().RecieveAttack(1);

        enemies.First().ApplyStatus(new ShockedStatus());
    }
}