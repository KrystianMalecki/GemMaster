using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Core;
using UnityEngine;
[System.Serializable]
[CreateAssetMenu(fileName = "_ MoveGem", menuName = "Custom/MoveGem")]
public class MoveGem : CodeGem
{
    public override void Execute(LogicObject lobject, GemLogicBlock glb)
    {
        base.Execute(lobject,glb);
        Debug.Log("MOve logiuc");
        lobject.Move(Vector3.up * 1,glb);
     
 
    }
    
}
