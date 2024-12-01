using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiceCustomizationUI : MonoBehaviour
{
    [SerializeField] private TMP_Text rerrolls;
    [SerializeField] private GameObject[] adventurers;
    [SerializeField] private GameObject[] dice;
    private int selectedAdventurerIndex = 0, selectedDieIndex = 0;
    [SerializeField] private GameObject facesListContainer;
    [SerializeField] private GameObject facesListItemPrefab;

    private void Start()
    {
        rerrolls.text = "Rerrolls: " + GameData.Instance.playerData.rerrols;
        OnSelectAdventurer(selectedAdventurerIndex);
        OnSelectDie(selectedDieIndex);
        RefreshFacesList();
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene("Board");
    }

    private GameObject SelectedAdventurer => adventurers[selectedAdventurerIndex];
    private GameObject SelectedDie => dice[selectedDieIndex];

    private void RefreshFacesList()
    {
        foreach (int index in new int[] { 0, 1, 2, 3})
        {
            GameObject faceListItem = Instantiate(facesListItemPrefab, facesListContainer.transform);
            faceListItem.GetComponentInChildren<TMP_Text>().text = $"Face {index}";
        }
    }

    public void OnSelectAdventurer(int adventurer)
    {
        SelectedAdventurer.transform.Find("Glow").gameObject.SetActive(false);
        selectedAdventurerIndex = adventurer;
        SelectedAdventurer.transform.Find("Glow").gameObject.SetActive(true);
    }

    public void OnSelectDie(int die)
    {
        SelectedDie.transform.Find("Glow").gameObject.SetActive(false);
        selectedDieIndex = die;
        SelectedDie.transform.Find("Glow").gameObject.SetActive(true);
    }
}
