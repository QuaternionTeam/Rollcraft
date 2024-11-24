using System.Linq;

internal class MageGold1 : Face
{
    internal override TargetsCount EnemiesCount => TargetsCount.All;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    public MageGold1(Unit unit) : base(unit) { }

    [Neutral]
    internal void NeutralAttack() => AttackAllEnemies(2);

    [Neutral]
    internal void ShockAllEnemies() => ApplyAllEnemies(new ShockedStatus());
}