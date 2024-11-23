internal class CombustionStatus : Status
{
    internal override void OnRecieveAttack(Unit unit, int damage)
    {
        unit.RecieveDamage(damage);
        unit.statuses.Remove(this);
    }
}