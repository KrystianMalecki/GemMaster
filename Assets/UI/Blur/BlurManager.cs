using DG.Tweening;
using DG.Tweening.Core;
using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BlurManager : MonoBehaviour
{
    public float transformationSpeed;
    public Volume blurVolume;
    Vector2 range = new Vector2(0, 0.2f);
    Vector2 bckrange = new Vector2(0, 0.7f);

    public Image img;
    public void ToggleBlur(bool value)
    {
        //  StopAllCoroutines();
        //  StartCoroutine(Blur(value));
        DOTween.To(() => { return v; }, new DOSetter<float>(set), value ? 1f : 0f, transformationSpeed).SetEase(Ease.Linear);
    }
    void set(float f)
    {
        v = f;
        blurVolume.weight = Mathf.Lerp(range.x, range.y, v);
        Color c = img.color;
        c.a = Mathf.Lerp(bckrange.x, bckrange.y, v);
        img.color = c;

    }
    [Button("on")]
    private void on()
    {
        ToggleBlur(true);
    }
    [Button("off")]

    void off()
    {
        ToggleBlur(false);

    }
    float v = 0f;
}
