using System.Linq;

internal class ArcherViolet1 : Face
{
    public ArcherViolet1(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.None;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    internal override string EffectString => "On Land: +1 Reroll\n+1 Reroll";

    [OnLand]
    [Neutral]
    internal void AddRerroll()
    {
        GameData.instance.AddRerroll();
    }
}