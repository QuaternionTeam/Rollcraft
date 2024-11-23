using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject square;

    void Start()
    {
        Instantiate(square, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
