using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "_ CodeGem", menuName = "Custom/CodeGem")]
public class CodeGem : ScriptableObject
{
    public Sprite image;
    public virtual void Execute()
    {

    }
}
