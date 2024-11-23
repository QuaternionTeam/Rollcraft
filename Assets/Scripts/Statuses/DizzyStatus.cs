internal class DizzyStatus : Status
{
    internal override void OnRecieveAttack(Unit unit, int damage)
    {
        unit.isStunned = true;
        unit.statuses.Remove(this);
    }
}