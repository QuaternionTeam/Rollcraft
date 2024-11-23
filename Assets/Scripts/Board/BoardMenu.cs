using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardMenu : MonoBehaviour
{
    public void OnMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
