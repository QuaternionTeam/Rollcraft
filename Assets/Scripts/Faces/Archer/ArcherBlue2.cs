using System.Linq;

internal class ArcherBlue2 : Face
{
    public ArcherBlue2(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    internal override void OnLand()
    {
        base.OnLand();

        //TODO: RANDOMENEMY.RecieveAttack(1);
    }

    internal override void ApplyEffect() 
    {
        base.ApplyEffect();

        enemies.First().RecieveAttack(1);
    }
}