using UnityEngine;

public class BoardCam : MonoBehaviour
{
    void Awake()
    {
        Camera.main.orthographicSize = GetHeightProportion() * 5 / 56.25f;
    }

    float GetHeightProportion()
    {
        return ((float)Screen.height * 100) / (float)Screen.width;
    }
}
