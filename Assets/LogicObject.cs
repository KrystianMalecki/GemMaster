using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicObject : MonoBehaviour
{
    //add state logging for backtracking
    public virtual void Activate(GemLogicBlock glb)
    {
        gameObject.SetActive(true);
        glb.HalfMTTNS();
    }
    public virtual void Deactivate(GemLogicBlock glb)
    {
        gameObject.SetActive(false);
        glb.HalfMTTNS();
    }
    public virtual void Move(Vector2 vector, GemLogicBlock glb)
    {
        glb.HalfMTTNS();
    }
}
