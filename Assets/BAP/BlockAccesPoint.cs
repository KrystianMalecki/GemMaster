using NaughtyAttributes;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BlockAccesPoint : MonoBehaviour
{

    [Foldout("Static Data")] public FollowerMovement attached;
    [Foldout("Static Data")] public Animator animator;
    public UnityEvent OnAttach;
    public UnityEvent OnDeattach;
    public UnityEvent OnExecute;

    public void Attach(FollowerMovement fm)
    {
        attached = fm;
        attached.Attach();
     //   animator.Play("Attach");
        animator.Play("Attach new");

        OnAttach.Invoke();
    }
    public void Execute()
    {
        OnExecute.Invoke();

    }
    public void Deattach()
    {
        StartCoroutine(deattach());
        OnDeattach.Invoke();
    }
    IEnumerator deattach()
    {
     //   animator.Play("Deattach");
            animator.Play("Deattach new");

        //   yield return new WaitForSeconds(50f / 60f);
           yield return new WaitForSeconds(60f / 60f);

        attached.Deattach(); 
        attached = null;

    }
}
