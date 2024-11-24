using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text rerrolls;
    internal static BoardMenu instance;

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
