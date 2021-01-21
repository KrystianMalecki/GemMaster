using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAccesPoint : MonoBehaviour
{
    public FollowerMovement attached;
    public Animator anim;
   public void Attach(FollowerMovement fm)
    {
        attached = fm;
        attached.attachedToBAP = true;
        attached.img.gameObject.SetActive(false);
        anim.Play("Attach");
        Debug.Log("Ataching");
    }
    public void Execute()
    {

    }
    public void Deattach()
    {



        StartCoroutine(deattach());
    }
    IEnumerator deattach()
    {
        anim.Play("Deattach");
        yield return new WaitForSeconds(50f / 60f);
        attached.attachedToBAP = false;
        attached.img.gameObject.SetActive(true);    
        attached = null;

    }
}
