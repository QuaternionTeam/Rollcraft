internal class ShockedStatus : Status
{
    internal override void OnRecieveAttack(Unit unit, int damage)
    {
        unit.RecieveDamage(1);
    }
}