using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public string playerName;
    public string highScorePlayer;
    public int highScore = 0;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
        instance.LoadPlayerData();
    }

    [System.Serializable]
    public class SaveData
    {
        public string HighScoreName;
        public int Score;
    }
    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.HighScoreName = highScorePlayer;
        data.Score = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayer = data.HighScoreName;
            highScore = data.Score;
        }
    }
}
