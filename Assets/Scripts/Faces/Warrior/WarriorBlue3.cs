using System.Linq;

internal class WarriorBlue3 : Face
{
    public WarriorBlue3(Unit unit) : base(unit) { }

    internal override TargetsCount EnemiesCount => TargetsCount.One;

    internal override TargetsCount AdventurersCount => TargetsCount.None;

    internal override string EffectString => "Apply Dizzy";

    [Neutral]
    internal void ApplyDizzy() => Apply(enemyTarget, new DizzyStatus());
}