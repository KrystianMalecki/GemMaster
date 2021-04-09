public class GemPickup : PickupObject
{
    public Gem gem;

    public override void Pickup(Entity entity)
    {
        if (entity is PlayerScript)
        {
            GemManager.instance.collectedGems.Add(gem);
            base.Pickup(entity);
        }
    }
    public override void Setup(Level l, int id)
    {
        base.Setup(l, id);
        up();
    }


}
