using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maker
{
    [UnityEditor.MenuItem("addsoundpoints", menuItem = "Tools/addsoundpoints")]
    public static void addsoundpoints()
    {
        AudioSource[] asses = GameObject.FindObjectsOfType<AudioSource>(true);

        for (int i = 0; i < asses.Length; ++i)
        {
            SoundPoint sp = asses[i].gameObject.AddComponent<SoundPoint>();
            sp.audioSource = asses[i];
            sp.isMusic = false;
        }
    }
}
