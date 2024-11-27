using System.IO;
using Unity.VisualScripting;
using UnityEngine;

internal class Data
{
    public int rerrols = 3;
}

internal class GameData : MonoBehaviour
{
    internal static GameData Instance => PersistentGameObject.Instance.GetOrAddComponent<GameData>();

    private Data _playerData;
    internal Data playerData { get { if (_playerData == null) InitializePlayerData(); return _playerData; } }

    private string saveFilePath => Application.persistentDataPath + "/PlayerData.json";

    internal bool generated = false;
    internal SquareType[,] grid = new SquareType[Board.realWidth, Board.realHeight];

    void InitializePlayerData()
    {
        Load();
        Save();
    }

    void Save()
    {
        string savePlayerData = JsonUtility.ToJson(_playerData);
        File.WriteAllText(saveFilePath, savePlayerData);
    }

    void Load()
    {
        // if (File.Exists(saveFilePath))
        // {
        //     string loadPlayerData = File.ReadAllText(saveFilePath);
        //     _playerData = JsonUtility.FromJson<Data>(loadPlayerData);
        // }
        // else
        // {
        _playerData = new Data();
        Save();
        // }
    }

    internal void AddRerroll()
    {
        _playerData.rerrols++;
        Save();
    }
}
