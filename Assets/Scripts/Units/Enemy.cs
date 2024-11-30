using UnityEngine;

internal class Enemy : Unit 
{ 
    internal override void Awake()
    {
        base.Awake();
        
        var dieInstance = Instantiate(Die, transform.position + new Vector3(0, -3f, 0), Quaternion.identity, transform);
    
        Die = dieInstance.GetComponent<Die>();
    }
}