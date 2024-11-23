using System.Linq;
using TMPro;
using Unity.VisualScripting;

internal class WarriorBlue1 : Face
{
    internal override TargetsCount EnemiesCount => 
        unit.quickness == Quickness.Fast ? TargetsCount.One : TargetsCount.None;

    internal override TargetsCount AdventurersCount => 
         unit.quickness == Quickness.Slow ? TargetsCount.One : TargetsCount.None;
    public WarriorBlue1(Unit unit) : base(unit) { }

    internal override void ApplyEffect() 
    {
        base.ApplyEffect();

        if(unit.quickness == Quickness.Fast)
            enemies.First().RecieveAttack(2);

        if(unit.quickness == Quickness.Slow)
            adventurers.First().RecieveShield(2);
    }
}