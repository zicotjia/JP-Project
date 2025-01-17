using System;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;
    public Color teamColor;

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
    }
    public void SaveColor() {
        SaveData data = new SaveData();
        data.teamColor = teamColor;

        string json = JsonUtility.ToJson(data);
        Debug.Log(json + " Saved in " + Application.persistentDataPath);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadColor() {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log("Loading");
        if (File.Exists(path)) {
            Debug.Log("json" + " Loaded in " + Application.persistentDataPath);
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            teamColor = data.teamColor;
        }
    }
}

[System.Serializable]
class SaveData
{
    public Color teamColor;
}

