using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreTebak : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] TextMeshProUGUI keterangan;

    void Start()
    {
        timerText.text = PlayerPrefs.GetString("tebakTimer");
        scoreText.text = PlayerPrefs.GetInt("tebakSkor").ToString();

        if (PlayerPrefs.GetInt("tebakSkor") >= 80)
        {
            keterangan.text = "Kamu Hebat !";
        }
        else
        {
            keterangan.text = "Belajar lagi yaa...";
        }
    }
}
