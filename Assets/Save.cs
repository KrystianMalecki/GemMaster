using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Save
{
    [SerializeField]
    public List<LevelData> levelDatas = new List<LevelData>();
    public LevelTag lastLvl = LevelTag.debug;
    public DoorDir lastDir;

    [SerializeField]
    public List<Gem> gems = new List<Gem>();

    public int currentHP;
    public int maxHP;

    public int collectableCount;

    public bool isEng;

    public float sfxVolume;
    public float musicVolume;

    public int quality;
}
