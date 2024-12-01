using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

internal class BoardUI : MonoBehaviour
{
    [SerializeField] private TMP_Text rerrolls;
    internal static BoardUI instance;

    private void Start()
    {
        instance = this;
        rerrolls.text = "Rerrolls: " + GameData.Instance.playerData.rerrols;
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnDiceCustomizationButton()
    {
        SceneManager.LoadScene("DiceCustomization");
    }

    internal void UpdateRerrolls()
    {
        rerrolls.text = "Rerrolls: " + GameData.Instance.playerData.rerrols;
    }
}
