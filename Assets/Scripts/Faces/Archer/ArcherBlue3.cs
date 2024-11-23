internal class ArcherBlue3 : Face
{
    public ArcherBlue3(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.All;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    internal override void ApplyEffect() 
    {
        base.ApplyEffect();

        foreach (var enemy in enemies)
            enemy.RecieveAttack(1);
    }
}