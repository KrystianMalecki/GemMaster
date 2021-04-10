using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : PickupObject
{
    public override void Pickup(Entity entity)
    {
        if (entity is PlayerScript)
        {
            GameManager.instance.SetChips(SaveManager.instance.currentSave.collectableCount + 1);
            base.Pickup(entity);
        }
    }
}
