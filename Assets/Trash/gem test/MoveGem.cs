using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "_ MoveGem", menuName = "Custom/MoveGem")]
public class MoveGem : CodeGem
{
    public override void Execute(LogicObject lobject)
    {
        base.Execute(lobject);
        Debug.Log("MOve logiuc");
        lobject.Move(Vector3.up * 1000);
 
    }
}
