using DG.Tweening;
using UnityEngine;
using NaughtyAttributes;
public class SpikesTile : DamageDealer
{
    public Transform spikes;
    //make better animation
    [Button("Activate")]
    public void Activate()
    {
        spikes.DOLocalMoveY(0, 0.3f).SetEase(Ease.OutCubic);
    }
    [Button("Dectivate")]

    public void Deactivate()
    {
        spikes.DOLocalMoveY(-0.4f, 0.3f).SetEase(Ease.OutCubic);
    }
   
}
