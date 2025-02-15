using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreMemory : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI keterangan;

    void Start()
    {
        timerText.text = PlayerPrefs.GetString("memoryTimer");
        scoreText.text = Mathf.Floor(PlayerPrefs.GetFloat("memorySkor")).ToString();

        if (PlayerPrefs.GetFloat("memorySkor") >= 80)
        {
            keterangan.text = "Kamu Hebat !";
        }
        else
        {
            keterangan.text = "Belajar lagi yaa...";
        }
    }
}
