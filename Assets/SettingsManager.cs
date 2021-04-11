using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using NaughtyAttributes;
public enum GameKey { Jump, Left, Right, Down, Interact, Connect, Edit, CloseWindow, Menu }
public class SettingsManager : MonoBehaviour
{
    public static SettingsManager instance;
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
        musicVolume = SaveManager.instance.currentSave.musicVolume;
        sfxVolume = SaveManager.instance.currentSave.sfxVolume;
        musicSlider.value = musicVolume;
        sfxSlider.value = sfxVolume;
        ChangeQuality(SaveManager.instance.currentSave.quality);
    }
    [SerializeField]
    public Dictionary<GameKey, KeyBinding> keyBinding = new Dictionary<GameKey, KeyBinding>()
    {
          {GameKey.Jump,new KeyBinding(KeyCode.UpArrow,KeyCode.W) },
          {GameKey.Left,new KeyBinding(KeyCode.LeftArrow,KeyCode.A) },
          {GameKey.Right,new KeyBinding(KeyCode.RightArrow,KeyCode.D) },
          {GameKey.Down,new KeyBinding(KeyCode.DownArrow,KeyCode.S) },
          {GameKey.Interact,new KeyBinding(KeyCode.E) },
          {GameKey.Connect,new KeyBinding(KeyCode.R) },
          {GameKey.Edit,new KeyBinding(KeyCode.Q) },
          {GameKey.CloseWindow,new KeyBinding(KeyCode.Escape) },
           {GameKey.Menu,new KeyBinding(KeyCode.M) },

    };

    public KeyCode GetKey(GameKey key)
    {
        KeyBinding kc = new KeyBinding();
        if (!keyBinding.TryGetValue(key, out kc))
        {
            Debug.Log("Can't find keybinding for " + key.ToString());
        }
        return isAlternativeModeOn ? kc.alternativeKey : kc.key;
    }
    public bool IsKeyPressed(GameKey key)
    {
        KeyBinding kc = new KeyBinding();
        if (!keyBinding.TryGetValue(key, out kc))
        {
            Debug.Log("Can't find keybinding for " + key.ToString());
        }
        return Input.GetKey(kc.alternativeKey) || Input.GetKey(kc.key);
    }
    public bool IsKeyPressedDown(GameKey key)
    {
        KeyBinding kc = new KeyBinding();
        if (!keyBinding.TryGetValue(key, out kc))
        {
            Debug.Log("Can't find keybinding for " + key.ToString());
        }
        return Input.GetKeyDown(kc.alternativeKey) || Input.GetKeyDown(kc.key);
    }
    public bool isAlternativeModeOn;
    public void Update()
    {
    }
    public KeyCode GetKeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            return KeyCode.UpArrow;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            return KeyCode.DownArrow;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            return KeyCode.LeftArrow;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            return KeyCode.RightArrow;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            return KeyCode.Escape;
        }
        else
        {
            KeyCode kc = KeyCode.None;
            if (chartoKeycode.TryGetValue(Input.inputString[0], out kc))
            {
                return kc;
            }
            return kc;
        }
    }
    Dictionary<char, KeyCode> chartoKeycode = new Dictionary<char, KeyCode>()
{ 
  //Lower Case Letters
  {'a', KeyCode.A},
  {'b', KeyCode.B},
  {'c', KeyCode.C},
  {'d', KeyCode.D},
  {'e', KeyCode.E},
  {'f', KeyCode.F},
  {'g', KeyCode.G},
  {'h', KeyCode.H},
  {'i', KeyCode.I},
  {'j', KeyCode.J},
  {'k', KeyCode.K},
  {'l', KeyCode.L},
  {'m', KeyCode.M},
  {'n', KeyCode.N},
  {'o', KeyCode.O},
  {'p', KeyCode.P},
  {'q', KeyCode.Q},
  {'r', KeyCode.R},
  {'s', KeyCode.S},
  {'t', KeyCode.T},
  {'u', KeyCode.U},
  {'v', KeyCode.V},
  {'w', KeyCode.W},
  {'x', KeyCode.X},
  {'y', KeyCode.Y},
  {'z', KeyCode.Z},
  
  //KeyPad Numbers
  {'1', KeyCode.Keypad1},
  {'2', KeyCode.Keypad2},
  {'3', KeyCode.Keypad3},
  {'4', KeyCode.Keypad4},
  {'5', KeyCode.Keypad5},
  {'6', KeyCode.Keypad6},
  {'7', KeyCode.Keypad7},
  {'8', KeyCode.Keypad8},
  {'9', KeyCode.Keypad9},
  {'0', KeyCode.Keypad0},
  
  //Other Symbols
  {'!', KeyCode.Exclaim}, //1
  {'"', KeyCode.DoubleQuote},
  {'#', KeyCode.Hash}, //3
  {'$', KeyCode.Dollar}, //4
  {'&', KeyCode.Ampersand}, //7
  {'\'', KeyCode.Quote}, //remember the special forward slash rule... this isnt wrong
  {'(', KeyCode.LeftParen}, //9
  {')', KeyCode.RightParen}, //0
  {'*', KeyCode.Asterisk}, //8
  {'+', KeyCode.Plus},
  {',', KeyCode.Comma},
  {'-', KeyCode.Minus},
  {'.', KeyCode.Period},
  {'/', KeyCode.Slash},
  {':', KeyCode.Colon},
  {';', KeyCode.Semicolon},
  {'<', KeyCode.Less},
  {'=', KeyCode.Equals},
  {'>', KeyCode.Greater},
  {'?', KeyCode.Question},
  {'@', KeyCode.At}, //2
  {'[', KeyCode.LeftBracket},
  {'\\', KeyCode.Backslash}, //remember the special forward slash rule... this isnt wrong
  {']', KeyCode.RightBracket},
  {'^', KeyCode.Caret}, //6
  {'_', KeyCode.Underscore},
  {'`', KeyCode.BackQuote},
  {' ', KeyCode.Space}





};

    [Foldout("Sound")] public float musicVolume;
    [Foldout("Sound")] public float sfxVolume;

    [Foldout("Sound")] public UnityEvent onMusicVolumeChange;
    [Foldout("Sound")] public UnityEvent onSfxVolumeChange;

    [Foldout("Sound")] public Slider musicSlider;
    [Foldout("Sound")] public Slider sfxSlider;

    [Foldout("Sound")] public TextMeshProUGUI musicText;
    [Foldout("Sound")] public TextMeshProUGUI sfxText;

    public void UpdateSFXVolume()
    {
        sfxVolume = sfxSlider.value;
        sfxText.text = "SFX Volume: " + (sfxVolume * 100).ToString("0") + "%";

        onSfxVolumeChange.Invoke();
    }
    public void UpdateMusicVolume()
    {
        musicVolume = musicSlider.value;
        musicText.text = "Music Volume: " + (musicVolume * 100).ToString("0") + "%";
        onMusicVolumeChange.Invoke();
    }

    [Foldout("Quality")] public Toggle lowQuality;
    [Foldout("Quality")] public Toggle mediumQuality;
    [Foldout("Quality")] public Toggle hightQuality;


    [Foldout("Quality")] public int quality = 0;
    public void ChangeQuality(int index)
    {
        quality = index;

        lowQuality.SetIsOnWithoutNotify(index == 0);
        mediumQuality.SetIsOnWithoutNotify(index == 1);
        hightQuality.SetIsOnWithoutNotify(index == 2);
        QualitySettings.SetQualityLevel(index, true);
    }
}
[System.Serializable]
public class KeyBinding
{
    public KeyCode key;
    public KeyCode alternativeKey;
    public KeyBinding(KeyCode kc1 = KeyCode.None, KeyCode kc2 = KeyCode.None)
    {
        key = kc1;
        alternativeKey = kc2;
    }
}
