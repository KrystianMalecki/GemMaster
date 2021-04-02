using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();
    YieldInstruction yi;
    public float loopTime;
    public SpriteRenderer sr;
    public TextMeshProUGUI letter;
    public void Start()
    {
        if (sprites.Count > 0)
        {
            yi = new WaitForSeconds(loopTime / sprites.Count);
            StartCoroutine(animate());
        }
    }
    public void OnEnable()
    {
        Start();
    }
    IEnumerator animate()
    {
        int a = 0;
        while (true)
        {
            if (a >= sprites.Count)
            {
                a = 0;
            }
            sr.sprite = sprites[a];
            a++;
            yield return yi;
        }
    }
}
