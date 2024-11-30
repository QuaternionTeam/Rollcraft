using UnityEngine;

internal class CombatHUD : MonoBehaviour
{
    [SerializeField] protected Health Health;

    internal void Start()
    {
        CombatData.hud = this;
    }

    internal Health InstanciateHealth(Unit unit, Vector3 position)
    {
        Health health = Instantiate(Health, position, Quaternion.identity, transform);
        health.Attach(unit);

        return health;
    }
}
