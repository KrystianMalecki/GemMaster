using DG.Tweening;
using UnityEngine;

public class HeartPickup : PickupObject
{
    public override void Pickup(Entity entity)
    {
        entity.AddHP(1);

        base.Pickup(entity);
    }
    void Start()
    {
        up();
    }
    void up()
    {

        transform.DOLocalMoveY(transform.position.y + 0.2f, 2f).OnComplete(down);
    }
    void down()
    {
        transform.DOLocalMoveY(transform.position.y - 0.2f, 2f).OnComplete(up);
    }
   
}
