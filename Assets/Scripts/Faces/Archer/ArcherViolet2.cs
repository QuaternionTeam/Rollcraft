using System.Linq;

internal class ArcherViolet2 : Face
{
    public ArcherViolet2(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    internal override void OnLand()
    {
        base.OnLand();

        //TODO: REROLL +1
    }

    internal override void ApplyEffect() 
    {
        base.ApplyEffect();

        enemies.First().RecieveAttack(1);

        enemies.First().RecieveAttack(1);
    }
}