using UnityEngine;
using NaughtyAttributes;
public class PickupObject : MonoBehaviour
{

    public virtual void Pickup(Entity entity)
    {
        DG.Tweening.DOTween.Kill(this, false);
        lvl.Pickuped(id);
        gameObject.SetActive(false); 

    }
    [ReadOnly] public int id;
    [ReadOnly] public Level lvl;
    public virtual void Setup(Level l, int id)
    {
        gameObject.SetActive(true);

        lvl = l;
        this.id = id;
    }
}
