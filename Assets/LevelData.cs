using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum LevelTag { }
[System.Serializable]
public class LevelData
{
    public LevelTag tagName;
    public GameObject mainPart;
    //TODO: add spawning enemies
}
