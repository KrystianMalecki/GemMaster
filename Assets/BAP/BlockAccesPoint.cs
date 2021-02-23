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
    bool canExecute;
    public void Attach(FollowerMovement fm)
    {
        attached = fm;
        attached.Attach();
        animator.Play("Attach new");
        StartCoroutine(attach());
    }
    IEnumerator attach()
    {
//        animator.Play("Deattach new");

        yield return new WaitForSeconds(40f / 60f);
        Destroy(Instantiate(GameManager.instance.particles, transform.position, Quaternion.identity), 2f);
        OnAttach.Invoke();
        canExecute = true;

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
    public void Update()
    {
        if (canExecute)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Execute();
            }
        }
    }
    IEnumerator deattach()
    {
        //   animator.Play("Deattach");
        canExecute = false;
        animator.Play("Deattach new");

        //   yield return new WaitForSeconds(50f / 60f);
        yield return new WaitForSeconds(60f / 60f);

        attached.Deattach();
        attached = null;

    }
}
