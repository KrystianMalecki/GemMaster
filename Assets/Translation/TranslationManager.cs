using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class TranslationManager : MonoBehaviour
{
    public static TranslationManager instance;
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

        isEng = SaveManager.instance.currentSave.isEng;


    }

    public List<Translation> translations = new List<Translation>();
    public bool isEng;
    public string GetTranslation(string txt)
    {
        Translation t = translations.Find(x => txt == x.tag);
        if (t == null)
        {
            Debug.LogWarning("Can't find translaion for '" + txt + "'");
            return txt;
        }
        if (isEng)
        {
            return t.eng;
        }
        else
        {
            return t.pl;
        }
    }
    public string Translate(string txt)
    {
        string[] parts = Regex.Split(txt, "([{}])");// txt.Split('{', '}');
        List<string> betterParts = new List<string>();

        for (int i = 0; i < parts.Length; i++)
        {

            if (parts[i] == "{")
            {

                betterParts.Add(GetTranslation(parts[i + 1]));
                i += 2;
            }
            else
            {
                betterParts.Add(parts[i]);
            }
        }
        return string.Join("", betterParts);
    }
}

