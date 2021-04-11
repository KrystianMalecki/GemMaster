using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using CodeHelper;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
    }





    [Foldout("Prefabs")] public GameObject particles;
    public Transform dragHead;
    public ButtonAnimation button;
    public TextMeshProUGUI chipText;
    public void SetChips(int count)
    {
        SaveManager.instance.currentSave.collectableCount = count;
        chipText.text = "; " + TranslationManager.instance.Translate("{chips}").ColorForTMPro(GPUIManager.cmdYellow) + " = " + count.ToString("0") + ";";
    }
    public void MoveButton(Transform tr, char c)
    {
        button.transform.position = (tr.position + new Vector3(0, -0.7f, 0)).AlignToPixel();
        button.gameObject.SetActive(true);
        button.letter.text = c.ToString();
    }
    public void HideButton()
    {
        button.gameObject.SetActive(false);

    }
    public void Start()
    {
        SetChips(SaveManager.instance.currentSave.collectableCount);
    }
}
