using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text rerrolls;

    private void Start()
    {
        rerrolls.text = "Rerrolls: " + GameData.instance.playerData.rerrols;
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
