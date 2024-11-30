internal class CombustionStatus : Status
{
    internal override void OnRecieveAttack(Unit unit, int damage)
    {
        unit.Damage(damage);
        unit.statuses.Remove(this);
    }
}