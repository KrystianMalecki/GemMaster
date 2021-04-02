using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening.Core;
using UnityEngine.UI;
using DG.Tweening;

public class BarAnimator : MonoBehaviour
{
    public Vector2 durationRange;
    public Image bar;
    public Ease ease;

    public void Start()
    {

        StartAnimation(false);
    }
    public void StartAnimation(bool direction)
    {
        float duration = Mathf.Lerp(durationRange.x, durationRange.y, Random.Range(0f, 1f));
        DOTween.To(() => { return v; }, new DOSetter<float>(set), direction ? 1f : 0f, duration).SetEase(ease).OnComplete(() => { StartAnimation(!direction); });
    }
    float v;
    void set(float f)
    {
        v = f;
        bar.fillAmount = v;
    }

}
