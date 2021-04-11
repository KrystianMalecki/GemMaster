using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
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
        blurManager.ToggleBlur(false);
        gpuiManager.gameObject.SetActive(false);
    }
    public BlurManager blurManager;
    public GPUIManager gpuiManager;
    public PauseScreenUI psui;

    public void OpenProgrammingUI(GemLogicBlock glb)
    {
        blurManager.ToggleBlur(true);
        gpuiManager.Open(glb);
    }
    public void HidePUI()
    {
        gpuiManager.Hide();
        blurManager.ToggleBlur(false);
        psui.Hide();
    }

    public void Update()
    {
        if ((SettingsManager.instance.IsKeyPressedDown(GameKey.Menu)))
        {
            psui.Show();
        }
        if ((SettingsManager.instance.IsKeyPressedDown(GameKey.CloseWindow)))
        {
            HidePUI();
            psui.Hide();

        }
    }
}
