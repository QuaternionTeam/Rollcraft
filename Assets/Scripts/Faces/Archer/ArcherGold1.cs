using System.Linq;

internal class ArcherGold1 : Face
{
    public ArcherGold1(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.All;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    internal override void ApplyEffect() 
    {
        base.ApplyEffect();

        foreach(var enemy in enemies)
        {
            enemy.RecieveAttack(1);

            enemy.RecieveAttack(1);
        }
    }
}