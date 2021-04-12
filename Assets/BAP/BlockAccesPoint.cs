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
    public UnityEvent OnQ;
    bool isAttached;
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
        isAttached = true;

    }
    
    public void Start()
    {
     //   LevelManager.instance.LevelChange.AddListener(Deattach);
    }
    public void OnDisable()
    {
    //    LevelManager.instance.LevelChange.RemoveListener(Deattach);

    }
    public void Execute()
    {
        OnExecute.Invoke();
    }
    public void Q()
    {
        OnQ.Invoke();
    }
    public void Deattach()
    {
        StartCoroutine(deattach());
        OnDeattach.Invoke();
    }
    public void Update()
    {
        if (isAttached)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Execute();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (PlayerScript.closestInteractableObject == null)
                {
                    Q();
                }
            }
        }
    }
    public IEnumerator deattach()
    {
        //   animator.Play("Deattach");
        isAttached = false;
        animator.Play("Deattach new");

        //   yield return new WaitForSeconds(50f / 60f);
        yield return new WaitForSeconds(60f / 60f);

        attached.Deattach();
        attached = null;

    }
}
