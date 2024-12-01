using UnityEngine;

internal class Enemy : Unit 
{ 
    internal override void Awake()
    {
        base.Awake();
        
        var dieInstance = Instantiate(Die, transform.position + new Vector3(0, -4f, 0), Quaternion.identity, transform);
        Die = dieInstance.GetComponent<Die>();

        var healthInstance = CombatData.Hud.InstanciateHealth(this, transform.position + new Vector3(0, 3f, 0));
        Health = healthInstance.GetComponent<Health>();
    }
}