using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueIO : InteractableObject
{
    public bool isOpened;
    public GameObject dialogueBox;//TODO: change to dialogue box scitpt
    public void Show()
    {
        isOpened = true;
        dialogueBox.SetActive(true);
        GameManager.instance.HideButton();

    }
    public void Hide()
    {
        isOpened = false;
        dialogueBox.SetActive(false);
        GameManager.instance.HideButton();
    }
    public void Toggle()
    {
        if (isOpened)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }
    public void Start()
    {
        Hide();
        OnInteract.AddListener(Toggle);
        OnExit.AddListener(Hide);
        OnEnter.AddListener(ShowButton);

    }
    public void ShowButton()
    {
        GameManager.instance.MoveButton(transform, SettingsManager.instance.GetKey(GameKey.Interact).ToString()[0]);
    }
}
