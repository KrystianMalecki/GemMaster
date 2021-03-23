using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GemSlot : MonoBehaviour, IDropHandler
{
    public UIGem gem;
    public int id = -1;
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    public void Setup(CodeGem cg, int id = -1)
    {
        gameObject.SetActive(true);

        this.id = id;
        if (cg != null)
        {
            if (gem == null)
            {
                UIGem uig = GemManager.instance.MakeUIGem(cg, this);
                gem = uig;
                uig.AddToSlot(this);
            }
            else if (gem.gem != cg)
            {
                Destroy(gem.gameObject);
                UIGem uig = GemManager.instance.MakeUIGem(cg, this);
                gem = uig;
                uig.AddToSlot(this);
            }
            else
            {
                //it is all ok!
            }
        }
    }
    public void Setup(UIGem uig)
    {
        gem = uig;
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + "was dropped on " + gameObject.name);

        //UIGem d = eventData.pointerDrag.GetComponent<UIGem>();

        if (UIGem.selected != null)
        {
            if (gem == null)
            {
                UIGem.selected.startSlot.gem = null;
                UIGem.selected.AddToSlot(this);
            }
        }
    }
}
