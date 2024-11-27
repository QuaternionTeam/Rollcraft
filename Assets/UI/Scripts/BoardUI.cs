using System;
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
        rerrolls.text = "Rerrolls: " + GameData.instance.playerData.rerrols;
    }

    public void OnMenuButton()
    {
        if (SceneManager.GetActiveScene().name == "Combat")
            SceneManager.LoadScene("Board");
        else
            SceneManager.LoadScene("MainMenu");
    }

    internal void UpdateRerrolls()
    {
        rerrolls.text = "Rerrolls: " + GameData.instance.playerData.rerrols;
    }
}
