using DG.Tweening;
using UnityEngine;

public class SpikesTile : DamageDealer
{
    public Transform spikes;
    //make better animation
    public void Activate()
    {
        spikes.DOLocalMoveY(0, 0.3f).SetEase(Ease.OutCubic);
    }
    public void Deactivate()
    {
        spikes.DOLocalMoveY(-0.4f, 0.3f).SetEase(Ease.OutCubic);
    }
}
