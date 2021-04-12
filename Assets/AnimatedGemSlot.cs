using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedGemSlot : GemSlot
{
    public Image image;
    public Sprite normal;
    public Sprite moving;
    public Sprite locked;


    YieldInstruction yi = new WaitForSeconds(0.25f);
    public void Start()
    {
        OnEnable();
    }
    void OnEnable()
    {
        GemInventoryUI.OnStartDragging.AddListener(StartDraggingAnimation);
        GemInventoryUI.OnEndDragging.AddListener(EndDraggingAnimation);

    }
    void OnDisable()
    {
        GemInventoryUI.OnStartDragging.RemoveListener(StartDraggingAnimation);
        GemInventoryUI.OnEndDragging.RemoveListener(EndDraggingAnimation);

    }
    void StartDraggingAnimation()
    {
        if (gem != null) { return; }
        //Debug.Log(gameObject.name + " starting");
        StartCoroutine(Anim());
    }
    void EndDraggingAnimation()
    {
       // Debug.Log(gameObject.name + " ending");
        StopAllCoroutines();
    }
    IEnumerator Anim()
    {
        while (true)
        {
            image.sprite = normal;
            yield return yi;
            image.sprite = moving;
            yield return yi;
        }
    }
    public override void AcceptDrop()
    {
        base.AcceptDrop();
        EndDraggingAnimation();
        image.sprite = locked;
    }
    public override void ReturnGem()
    {
        base.ReturnGem();
        image.sprite = locked;

    }
    public override void RemoveGem()
    {
        base.RemoveGem();
        image.sprite = normal;
       
    }

}
