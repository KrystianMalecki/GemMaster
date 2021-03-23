using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class BlurManager : MonoBehaviour
{
    public float transformationSpeed;
    public Volume blurVolume;
    Vector2 range = new Vector2(0, 0.5f);
    public void ToggleBlur(bool value)
    {
        //  StopAllCoroutines();
        //  StartCoroutine(Blur(value));
        DOTween.To(new DOGetter<float>(get), new DOSetter<float>(set), value ? 1f : 0f, 10f);
    }
    void set(float f)
    {
        v = f;
        blurVolume.weight = Mathf.Clamp(v, range.x, range.y);
    }

    float get()
    {
        return v;
    }
    float v = 0f;
}
