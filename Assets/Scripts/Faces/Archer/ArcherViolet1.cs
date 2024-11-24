using System.Linq;

internal class ArcherViolet1 : Face
{
    public ArcherViolet1(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    [OnLand]
    [Neutral]
    internal void AddRerroll()
    {
        GameData.instance.AddRerroll();
    }
    
}