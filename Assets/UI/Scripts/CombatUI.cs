using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

internal class CombatUI : MonoBehaviour
{
    [SerializeField] private TMP_Text rerrolls;
    internal static CombatUI instance;

    private void Start()
    {
        instance = this;
        rerrolls.text = "Rerrolls: " + GameData.Instance.playerData.rerrols;
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene("Board");
    }

    internal void UpdateRerrolls()
    {
        rerrolls.text = "Rerrolls: " + GameData.Instance.playerData.rerrols;
    }
}
