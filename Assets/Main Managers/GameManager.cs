using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using CodeHelper;
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
    public void MoveButton(Transform tr, char c)
    {
        button.transform.position = (tr.position + new Vector3(0, -0.7f, 0)).AlignToPixel();
        button.gameObject.SetActive(true);
        button.letter.text = SettingsManager.instance.GetKey(GameKey.Interact).ToString();
    }
    public void HideButton()
    {
        button.gameObject.SetActive(false);

    }
}
