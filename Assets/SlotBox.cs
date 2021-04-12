using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotBox : MonoBehaviour
{
    public GemSlot functionSlot;
    public GemSlot numberSlot;
    public DataSlot dataSlot;
    public GemBox referance;
    public int id;
    public void Setup(GemBox gemBox, int id)
    {
        gameObject.SetActive(true);
        this.id = id;
        Debug.Log(gemBox.functionGem);
        functionSlot.Setup(gemBox.functionGem);
        numberSlot.Setup(gemBox.numberGem);
        dataSlot.SetData();
        //TODO: add data icon and logic
    }
    public void Hide()
    {
        gameObject.SetActive(false);

    }
    public void Save()
    {
        if (numberSlot.gem == null)
        {
            referance.numberGem = null;
        }
        else
        {
            referance.numberGem = numberSlot.gem.gem;
        }
        if (functionSlot.gem == null)
        {
            referance.functionGem = null;
        }
        else
        {
            referance.functionGem = functionSlot?.gem.gem;
        }
    }

}
