using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;
using NaughtyAttributes;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;
    public TextMeshProUGUI keyText;
    public GameObject menu;

    public void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }
    IEnumerator startTimer()
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < 100; i++)
        {
            keyText.alpha = 1f * i / 100f;
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void Start()
    {
        keyText.alpha = 0f;
        StartCoroutine(startTimer());
    }
    [ReadOnly] public bool started;
    public void Update()
    {
        if (started)
        { 
        
        }
        else
        {
            if (Input.inputString != string.Empty || Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
            {
                keyText.gameObject.SetActive(false);
                menu.transform.DOLocalMoveY(0, 2f).SetEase(Ease.OutBounce);
                started = true;
            }
        }
    }
    public void Quit()
    {

    }
    public void Credits()
    {

    }
    public void Play()
    {

    }
}
