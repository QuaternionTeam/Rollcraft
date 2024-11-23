using Unity.VisualScripting;
using UnityEngine;
internal class Clickleable : MonoBehaviour
{
    public TurnSystem turnSystem;
    public bool hasBeenClicked = false;

    void Start()
    {
        
    }

    void OnMouseDown()
    {
        turnSystem.HasBeenClicked(GetComponent<Unit>());
    }

    void Update()
    {
        
    }
}
