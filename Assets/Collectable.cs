using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : PickupObject
{
    public override void Pickup(Entity entity)
    {
        if (entity is PlayerScript)
        {
            base.Pickup(entity);
            GameManager.instance.SetChips(SaveManager.instance.currentSave.collectableCount + 1);

        }
    }
}
