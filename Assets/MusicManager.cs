using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public LevelTag lastLvl = LevelTag.none;
    public AudioSource audioSource;
    public AudioClip tutorial;
    public AudioClip temple1;
    public AudioClip temple2;
    public AudioClip end;


    public void Start()
    {
        LevelManager.instance.LevelChange.AddListener(ChangeMusic);
        //ChangeMusic();

    }
    public void ChangeMusic()
    {
        if (lastLvl == LevelManager.currentLevel.levelData.tagName)
        {
            return;
        }
        lastLvl = LevelManager.currentLevel.levelData.tagName;
        switch (lastLvl)
        {
            case LevelTag.tutorial:
                {
                    audioSource.clip = tutorial;
                    audioSource.Play();
                    break;
                }
            case LevelTag.templeout:
                {
                    audioSource.clip = temple1;
                    audioSource.Play();
                    break;
                }
            case LevelTag.temple2:
                {
                    audioSource.clip = temple2;
                    audioSource.Play();
                    break;
                }
            case LevelTag.end:
                {
                    audioSource.clip = end;
                    audioSource.Play();
                    break;
                }
        }
    }
}
