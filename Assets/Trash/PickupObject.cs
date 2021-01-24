using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
   public virtual void Pickup(Entity entity)
    {
        Destroy(gameObject);
    }
  
}
