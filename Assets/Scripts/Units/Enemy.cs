using UnityEngine;

internal class Enemy : Unit 
{ 
    internal override void Awake()
    {
        var dieInstance = Instantiate(Die, transform.position + new Vector3(0, -3f, 0), Quaternion.identity);
    
        Die = dieInstance.GetComponent<Die>();
    }
}