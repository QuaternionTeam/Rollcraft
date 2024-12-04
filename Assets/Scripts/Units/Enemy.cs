using UnityEngine;

internal class Enemy : Unit 
{ 
    internal override void Awake()
    {
        base.Awake();
        
        DieInstance = Instantiate(DiePrefab, transform.position + new Vector3(0, -4f, 0), Quaternion.identity, transform);
        DieInstance.SetOwner(this);
        
        HealthInstance = Instantiate(HealthPrefab, transform.position + new Vector3(0, 3f, 0), Quaternion.identity, transform);
        HealthInstance.Attach(this);

    }
}