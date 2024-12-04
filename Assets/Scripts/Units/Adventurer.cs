using UnityEngine;

internal class Adventurer : Unit 
{ 
    internal Quickness Quickness;
    internal bool HasDie { get; set; }

    internal override void Awake()
    {
        base.Awake();

        DieInstance = Instantiate(DiePrefab, new Vector3(0, -2f, 0), Quaternion.identity, transform);
        DieInstance.SetOwner(this);
        DieInstance.gameObject.SetActive(false);

        HealthInstance = Instantiate(HealthPrefab, transform.position + new Vector3(0, -3f, 0), Quaternion.identity, transform);
        HealthInstance.Attach(this);
    }

    internal override void RollDie()
    {
        base.RollDie();
        DieInstance.gameObject.SetActive(true);
    }

    internal override void ResolveDie()
    {
        base.ResolveDie();
        DieInstance.gameObject.SetActive(false);
    }
}