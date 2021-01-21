using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAccesPoint : MonoBehaviour
{
    public FollowerMovement attached;
   public void Attach(FollowerMovement fm)
    {
        attached = fm;
        attached.attachedToBAP = true;
        Debug.Log("Ataching");
    }
    public void Execute()
    {

    }
    public void Deattach()
    {
        attached.attachedToBAP = false;


        attached = null;
    }
}
