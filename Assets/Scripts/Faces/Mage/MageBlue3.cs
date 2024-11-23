using System.Linq;

internal class MageBlue3 : Face
{
    internal override TargetsCount EnemiesCount => TargetsCount.None;

    internal override TargetsCount AdventurersCount => TargetsCount.One;

    public MageBlue3(Unit unit) : base(unit) { }

    internal override void ApplyEffect() 
    {
        base.ApplyEffect();

        adventurers.First().RecieveHealing(2);
    }
}