using System.Linq;

internal class MageGold1 : Face
{
    internal override TargetsCount EnemiesCount => TargetsCount.All;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    public MageGold1(Unit unit) : base(unit) { }

    internal override void ApplyEffect() 
    {
        base.ApplyEffect();
        
        foreach (var enemy in enemies)
        {
            enemy.RecieveAttack(2);
            enemy.ApplyStatus(new ShockedStatus());
        }
    }
}