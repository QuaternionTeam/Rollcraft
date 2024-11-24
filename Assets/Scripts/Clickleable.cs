using UnityEngine;
internal class Clickleable : MonoBehaviour
{
    public TurnSystem turnSystem;
    public bool hasBeenClicked = false;

    void OnMouseDown()
    {
        turnSystem.HasBeenClicked(GetComponent<Unit>());
    }
}
