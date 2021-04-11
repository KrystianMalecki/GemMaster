using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPoint : MonoBehaviour
{
    public AudioSource audioSource;
    public bool isMusic;

    public void UpdateSound()
    {
        audioSource.volume = isMusic ? SettingsManager.instance.musicVolume : SettingsManager.instance.sfxVolume;
    }
    public void OnEnable()
    {
        if (isMusic)
        {
            SettingsManager.instance.onMusicVolumeChange.AddListener(UpdateSound);
        }
        else
        {
            SettingsManager.instance.onSfxVolumeChange.AddListener(UpdateSound);
        }
        UpdateSound();
    }
    public void OnDisable()
    {
        if (isMusic)
        {
            SettingsManager.instance.onMusicVolumeChange.RemoveListener(UpdateSound);
        }
        else
        {
            SettingsManager.instance.onSfxVolumeChange.RemoveListener(UpdateSound);
        }
    }
}
