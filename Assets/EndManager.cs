using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndManager : MonoBehaviour
{
    public static EndManager instance;
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
        }
    }
    public TextMeshProUGUI text;
    public void Count()
    {
        text.text ="Thanks for the playing the demo!\nYou collected: " +SaveManager.instance.currentSave.collectableCount+"\n";
    }
}
