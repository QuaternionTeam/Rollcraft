using System.Linq;

internal class ArcherGold1 : Face
{
    public ArcherGold1(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.All;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    [Neutral]
    internal void FirstAttack() => Attack(enemyTarget, 1);

    [Neutral]
    internal void SecondAttack() => Attack(enemyTarget, 1);
    //TODO ENEMYTARGET -> AllEnemies
}