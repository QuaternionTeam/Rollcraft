using UnityEngine;

internal class Player : MonoBehaviour
{
    internal void Activate()
    {
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
