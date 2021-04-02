using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using NaughtyAttributes;
using DG.Tweening.Core;
using CodeHelper;

public class RandomText : MonoBehaviour
{
    public enum RandomTextMode { RNumbers, RChars, RHex, DOTNumbers }

    public TextMeshProUGUI text;
    public RandomTextMode mode;

    [ShowIf("DOTNumbers")] public Vector2 numberRange;
    [ShowIf("DOTNumbers")] public Vector2 durationRange;
    [ShowIf("DOTNumbers")] public Ease ease;
    [ShowIf("R")] public Vector2 speedChange;
    [ShowIf("R")] public Vector2Int length;

    public void Start()
    {

        //  StartAnimation(false);
        switch (mode)
        {
            case RandomTextMode.DOTNumbers:
                {
                    StartDOTNumbers();
                    break;
                }
            case RandomTextMode.RNumbers:
            case RandomTextMode.RChars:
            case RandomTextMode.RHex:
                {
                    StartCoroutine(animationTick());
                    break;
                }


        }
    }
    public void Animate()
    {
        switch (mode)
        {
            case RandomTextMode.RNumbers:
                {
                    int len = length.RandomBetween();
                    string str = "";
                    for (int a = 0; a < len; a++)
                    {
                        str += Random.Range(0, 9).ToString("0");
                    }
                    text.text = str;
                    break;
                }
            case RandomTextMode.RChars:
                {
                    int len = length.RandomBetween();
                    string str = "";
                    for (int a = 0; a < len; a++)
                    {
                        str += CodeHelper.CodeHelper.alphabet[Random.Range(0, CodeHelper.CodeHelper.alphabet.Length - 1)];
                    }
                    text.text = str;
                    break;
                }
            case RandomTextMode.RHex:
                {
                    int len = length.RandomBetween();
                    string str = "";
                    for (int a = 0; a < len; a++)
                    {
                        str += "0x" + Random.Range(0, 255).ToString("X2") + " ";
                    }
                    text.text = str;
                    break;
                }
        }
    }
    IEnumerator animationTick()
    {
        while (true)
        {
            Animate();
            yield return new WaitForSeconds(speedChange.RandomBetween());
        }
    }
    float v;
    public void StartDOTNumbers()
    {
        float endValue = numberRange.RandomBetween();
        float duration = durationRange.RandomBetween();
        DOTween.To(() => { return v; }, new DOSetter<float>(set), endValue, duration).SetEase(ease).OnComplete(StartDOTNumbers);
    }
    void set(float f)
    {
        v = f;
        text.text = f.ToString("0.0");
    }
    bool DOTNumbers => mode == RandomTextMode.DOTNumbers;
    bool R => mode == RandomTextMode.RNumbers || mode == RandomTextMode.RChars || mode == RandomTextMode.RHex;
}
