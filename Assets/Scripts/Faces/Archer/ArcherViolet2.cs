using System.Linq;

internal class ArcherViolet2 : Face
{
    public ArcherViolet2(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    [OnLand]
    internal void ObtainReroll()
    {
        GameData.instance.AddRerroll();
    }

    [Neutral]
    internal void FirstAttack() => Attack(enemyTarget, 1);

    [Neutral]
    internal void SecondAttack() => Attack(enemyTarget, 1);
}