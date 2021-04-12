using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToBackpack : AnimatedGemSlot
{
    public GemInventoryUI giui;
    public int a;
    public override void AcceptDrop()
    {
        base.AcceptDrop();
        UIGem.selected.startSlot.RemoveGem();
        GemManager.instance.collectedGems.Add(UIGem.selected.gem);
        Destroy(UIGem.selected.gameObject);
        giui.SetupGems();
        giui.t(a);
    }
    public override bool CheckIfCanPlace(UIGem uigem)
    {
        if (uigem != null)
        {
            if (gem == null)
            {
                return true;


            }
        }
        return false;
    }
}
