using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    // Singleton handler of name and best Score
    // check to save data and
    // display best Score on Start menu

    public static GameManager Instance;
    public int score;
    public string playerName;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int score;
    }

    void SaveScore()
    {
        SaveData data = new SaveData();
        data.name = playerName;
        data.score = score;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public string GetBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.name;
            score = data.score;
            return $"Best Score: {playerName}: {score}";
        }
        return "";
    }

    /// To be called on gameStart
    public void SetName(string name)
    {
        playerName = name;
    }

    /// To be called on gameOver
    public void CheckScore(int newScore)
    {
        if (newScore > score)
        {
            score = newScore;
            SaveScore();
        }
    }
}
