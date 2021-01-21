using ConditionalAttribute;
using System.Collections;
using UnityEngine;
public class BlockAccesPoint : MonoBehaviour
{
    [SerializeField]
    private bool showMoreData;
    [ConditionalField("showMoreData")] public FollowerMovement attached;
    [ConditionalField("showMoreData")] public Animator animator;
    public void Attach(FollowerMovement fm)
    {
        attached = fm;
        attached.Attach();
        animator.Play("Attach");
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
        animator.Play("Deattach");
        yield return new WaitForSeconds(50f / 60f);
        attached.Deattach(); 
        attached = null;

    }
}
