using UnityEngine;
using UnityEngine.SceneManagement;

internal class MainMenu : MonoBehaviour
{
    public void onPlayButtonn()
    {
        SceneManager.LoadScene("Board");
    }
}
