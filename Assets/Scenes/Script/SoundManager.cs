using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SoundManager : MonoBehaviour
{
    public GameObject soundOn;
    public GameObject soundOff;
    private AudioSource audioSource;
    private const string SoundPrefKey = "SoundState";

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObj.Length > 0)
        {
            audioSource = musicObj[0].GetComponent<AudioSource>();
        }

        LoadSoundState();
    }

    public void ToggleSound()
    {
        if (audioSource != null)
        {
            audioSource.mute = !audioSource.mute;
            soundOn.SetActive(!audioSource.mute);
            soundOff.SetActive(audioSource.mute);

            PlayerPrefs.SetInt(SoundPrefKey, audioSource.mute ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    private void LoadSoundState()
    {
        if (audioSource != null)
        {
            bool isMuted = PlayerPrefs.GetInt(SoundPrefKey, 0) == 1;
            audioSource.mute = isMuted;
            soundOn.SetActive(!isMuted);
            soundOff.SetActive(isMuted);
        }
    }
}
