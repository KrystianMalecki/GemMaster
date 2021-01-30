public class GemPickup : PickupObject
{
    public CodeGem gemSO;

    public override void Pickup(Entity entity)
    {
        if (entity is PlayerScript)
        {
            base.Pickup(entity);
        }
    }
    void Start()
    {
    }

}
