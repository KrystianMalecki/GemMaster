using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class GemSlot : MonoBehaviour, IDropHandler
{
    public UIGem gem;
    public int id = -1;
    public GemType type;
    public bool isInventory = false;
    public SlotBox slotBox;
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }
    public virtual void Setup(Gem g, int id = -1)
    {
        gameObject.SetActive(true);

        this.id = id;
        if (g != null)
        {
            if (gem == null)
            {
                UIGem uig = GemManager.instance.MakeUIGem(g, this);
                gem = uig;
                uig.AddToSlot(this);
            }
            else if (gem.gem != g)
            {
                Destroy(gem.gameObject);
                UIGem uig = GemManager.instance.MakeUIGem(g, this);
                gem = uig;
                uig.AddToSlot(this);
            }
            else
            {
                //it is all ok!
            }
        }
        else
        {
            if (gem != null)
            {
                Destroy(gem.gameObject);
            }
            gem = null;
        }
    }
    public virtual void Setup(UIGem uig)
    {
        gem = uig;
    }
    public virtual void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + "was dropped on " + gameObject.name);

        //UIGem d = eventData.pointerDrag.GetComponent<UIGem>();

        if (CheckIfCanPlace(UIGem.selected))
        {
            AcceptDrop();
        }
    }
    public virtual bool CheckIfCanPlace(UIGem uigem)
    {
        if (uigem != null)
        {
            if (gem == null)
            {
                if (uigem.gem.type == type)
                {
                    return true;

                }
            }
        }
        return false;
    }
    public virtual void AcceptDrop()
    {
        gem = UIGem.selected;
        UIGem.selected.startSlot.RemoveGem();
        UIGem.selected.AddToSlot(this);
        slotBox?.dataSlot.SetData();
    }
    public virtual void ReturnGem()
    {


    }
    public virtual void RemoveGem()
    {
        if (isInventory)
        {
            GemManager.instance.collectedGems.Remove(gem.gem);
            Hide();
        }
        gem = null;

    }
}
