using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class LevelData
{
    public LevelTag tagName;

    public List<int> pickupIds = new List<int>();
    public List<GLBData> glbdatas = new List<GLBData>();
}
[System.Serializable]
public class GLBData
{
    public List<GemBox> gemBoxes = new List<GemBox>();
}
