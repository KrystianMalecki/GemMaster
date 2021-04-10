using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public Save defaultSave;
    public Save currentSave;
    public string saveName;
    public PlayerScript player;
    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        if (!PlayerPrefs.HasKey("notFirstBoot"))
        {
            PlayerPrefs.SetString("notFirstBoot", "true");
            SaveData(defaultSave, saveName);
        }
        currentSave = LoadData(saveName);
    }
    public void Start()
    {
        Load();

    }
    public void SaveData(Save save, string name)
    {
        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Create(Application.persistentDataPath
                     + "/Save-" + name + ".dat");
        bf.Serialize(file, save);
        file.Close();
        Debug.Log("Saved in " + Application.persistentDataPath
                     + "/Save-" + name + ".dat");
    }
    public Save LoadData(string name)
    {
        Save data = null;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file =
                   File.Open(Application.persistentDataPath
                     + "/Save-" + name + ".dat", FileMode.Open);
        data = (Save)bf.Deserialize(file);

        file.Close();

        Debug.Log("Game data loaded from " + Application.persistentDataPath
                     + "/Save-" + name + ".dat");

        return data;
    }
    public void OnDestroy()
    {
        Save();
        // SaveData(currentSave, saveName);
    }
    public void OnApplicationQuit()
    {
        Save();
    }
    public void Load()
    {
        currentSave = LoadData(saveName);
        foreach (LevelData ld in currentSave.levelDatas)
        {
            Level l = LevelManager.instance.levels.Find(x => x.levelData.tagName == ld.tagName);
            if (l == null)
            {
                Debug.LogError("Can't find level with tag: " + ld.tagName.ToString());
            }
            l.levelData = ld;
        }
        player.maxHP = currentSave.maxHP;
        player.currentHP = 0;
        player.AddHP(currentSave.currentHP);
    }
    public void Save()
    {
        currentSave.levelDatas.Clear();
        currentSave.isEng = TranslationManager.instance.isEng;

        foreach (Level l in LevelManager.instance.levels)
        {
            l.SaveData();
            currentSave.levelDatas.Add(l.levelData);
        }
        currentSave.lastLvl = LevelManager.currentLevel.levelData.tagName;
        currentSave.lastDir = LevelManager.currentDir;

        currentSave.maxHP = player.maxHP;
        currentSave.currentHP = player.currentHP;

        SaveData(currentSave, saveName);

    }
}

