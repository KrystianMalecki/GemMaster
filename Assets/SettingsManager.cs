using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public enum GameKey { Jump, Left, Right, Down, Interact, Connect, Edit, CloseWindow }
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
