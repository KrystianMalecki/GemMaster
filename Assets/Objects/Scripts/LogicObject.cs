using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicObject : MonoBehaviour
{
    //add state logging for backtracking
    public virtual void Toggle(GemLogicBlock glb, bool state)
    {
        gameObject.SetActive(state);
        glb.HalfMTTNS();
    }

    public virtual void Move(GemLogicBlock glb, Vector2 dir)
    {
        glb.HalfMTTNS();
    }
    public virtual void Rotate(GemLogicBlock glb, Vector2 dir)
    {
        glb.HalfMTTNS();
    }
    public virtual void Activate(GemLogicBlock glb/*,int id*/)
    {
        glb.HalfMTTNS();
    }
   /* public void Execute(int number, int number, GemExecutionType type, GemLogicBlock glb)
    {
        switch (type)
        {
            case GemExecutionType.Activate:
                {
                    Activate(glb);
                    break;
                }
            case GemExecutionType.Move:
                {
                    Activate(glb);
                    break;
                }
            case GemExecutionType.Activate:
                {
                    Activate(glb);
                    break;
                }
            case GemExecutionType.Activate:
                {
                    Activate(glb);
                    break;
                }
        }
    }*/
}
