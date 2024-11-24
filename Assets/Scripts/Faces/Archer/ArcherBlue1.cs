using System.Linq;

internal class ArcherBlue1 : Face
{
    public ArcherBlue1(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    [Neutral]
    internal void FirstAttack() => Attack(enemyTarget, 1);

    [Neutral]
    internal void SecondAttack() => Attack(enemyTarget, 1);
}