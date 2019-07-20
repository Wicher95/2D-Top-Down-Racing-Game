using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public GameObject soundDisabledObject;
    public GameObject musicDisabledObject;
    public AudioMixer audioMixer;

    public bool SoundEnabled
    {
        get
        {
            return PlayerPrefs.GetInt("SoundEnabled", 1) == 1 ? true : false;
        }
        set
        {
            PlayerPrefs.SetInt("SoundEnabled", value ? 1 : 0);
        }
    }

    public bool MusicEnabled
    {
        get
        {
            return PlayerPrefs.GetInt("MusicEnabled", 1) == 1 ? true : false;
        }
        set
        {
            PlayerPrefs.SetInt("MusicEnabled", value ? 1 : 0);
        }
    }

    private void Awake()
    {
        soundDisabledObject.SetActive(!SoundEnabled);
        musicDisabledObject.SetActive(!MusicEnabled);
        StartCoroutine(WaitForNextFrame());
    }

    IEnumerator WaitForNextFrame()
    {
        yield return new WaitForEndOfFrame();
        audioMixer.SetFloat("Sound", SoundEnabled ? 0 : -80);
        audioMixer.SetFloat("Music", MusicEnabled ? 0 : -80);
    }

    public void ChangeSoundStatus()
    {
        if (SoundEnabled)
        {
            SoundEnabled = false;
            audioMixer.SetFloat("Sound", -80);
            soundDisabledObject.SetActive(true);
        }
        else
        {
            SoundEnabled = true;
            audioMixer.SetFloat("Sound", 0);
            soundDisabledObject.SetActive(false);
        }
    }

    public void ChangeMusicStatus()
    {
        if (MusicEnabled)
        {
            MusicEnabled = false;
            audioMixer.SetFloat("Music", -80);
            musicDisabledObject.SetActive(true);
        }
        else
        {
            MusicEnabled = true;
            audioMixer.SetFloat("Music", 0);
            musicDisabledObject.SetActive(false);
        }
    }
}
