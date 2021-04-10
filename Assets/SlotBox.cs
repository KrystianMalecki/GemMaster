﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotBox : MonoBehaviour
{
    public GemSlot functionSlot;
    public GemSlot numberSlot;
    public DataSlot dataSlot;
    public int id;
    public void Setup(GemBox gemBox, int id)
    {
        gameObject.SetActive(true);
        this.id = id;
        functionSlot.Setup(gemBox.functionGem);
        numberSlot.Setup(gemBox.numberGem);
        //TODO: add data icon and logic
    }
    public void Hide()
    {
        gameObject.SetActive(false);

    }

}
