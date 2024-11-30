using UnityEngine;

internal class Adventurer : Unit 
{ 
    internal Quickness Quickness;
    internal bool HasDie { get; set; }

    internal override void Awake()
    {
        base.Awake();

        var dieInstance = Instantiate(Die, new Vector3(0, -5f, 0), Quaternion.identity, transform);
        
        Die = dieInstance.GetComponent<Die>();
        Die.SetOwner(this);
        Die.gameObject.SetActive(false);

        var healthInstance = CombatData.hud.InstanciateHealth(this, transform.position + new Vector3(0, -4f, 0));
        Health = healthInstance.GetComponent<Health>();
    }

    internal override void RollDie()
    {
        base.RollDie();
        Die.gameObject.SetActive(true);
    }

    internal override void ResolveDie()
    {
        base.ResolveDie();
        Die.gameObject.SetActive(false);
    }
}