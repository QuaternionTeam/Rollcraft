using System.IO;
using UnityEngine;

internal class Data
{
    public int rerrols = 3;
}

internal class GameData : MonoBehaviour
{
    private static GameData _instance;
    public static GameData instance { get { return _instance != null ? _instance : new GameObject().AddComponent<GameData>(); } set { _instance = value; } }


    private Data _playerData;
    internal Data playerData { get { if (_playerData == null) InitializePlayerData(); return _playerData; } }

    private string saveFilePath => Application.persistentDataPath + "/PlayerData.json";

    internal bool generated = false;
    internal SquareType[,] grid = new SquareType[Board.realWidth, Board.realHeight];

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this);
    }

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
