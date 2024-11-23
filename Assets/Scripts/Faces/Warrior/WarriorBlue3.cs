using System.Linq;

internal class WarriorBlue3 : Face
{
    public WarriorBlue3(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    internal override void ApplyEffect() 
    {
        base.ApplyEffect();

        enemies.First().ApplyStatus(new DizzyStatus());
    }
}