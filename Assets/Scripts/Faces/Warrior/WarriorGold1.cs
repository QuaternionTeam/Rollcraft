using System.Linq;

internal class WarriorGold1 : Face
{
    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.None;
    
    public WarriorGold1(Unit unit) : base(unit) { }

    internal override void ApplyEffect() 
    {
        base.ApplyEffect();

        enemies.First().RecieveAttack(5);
    }
}