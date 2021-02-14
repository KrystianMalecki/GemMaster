using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public virtual void Pickup(Entity entity)
    {
        DG.Tweening.DOTween.Kill(this, false);
        Destroy(gameObject);
    }

}
