using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontNotDestroy : MonoBehaviour
{
    public AudioClip lagu1; // Onboarding & Home
    public AudioClip lagu2; // Bermain & seterusnya
    public AudioClip lagu3; // Belajar & seterusnya
    public AudioClip lagu4; // Hasil

    private AudioSource audioSource;

    private void Awake()
    {
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        PlayMusicBasedOnScene(SceneManager.GetActiveScene().name);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayMusicBasedOnScene(scene.name);
    }

    private void PlayMusicBasedOnScene(string sceneName)
    {
        AudioClip selectedClip = null;

        if (sceneName == "Onboarding" || sceneName == "Home")
        {
            selectedClip = lagu1;
        }
        else if (sceneName == "Bermain" || sceneName.StartsWith("Bermain"))
        {
            selectedClip = lagu2;
        }
        else if (sceneName == "Belajar" || sceneName.StartsWith("Belajar"))
        {
            selectedClip = lagu3;
        }
        else if (sceneName == "Hasil")
        {
            selectedClip = lagu4;
        }

        if (selectedClip != null && audioSource.clip != selectedClip)
        {
            audioSource.clip = selectedClip;
            audioSource.Play();
        }
    }
}
