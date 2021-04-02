public class GemPickup : PickupObject
{
    public Gem gem;

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
