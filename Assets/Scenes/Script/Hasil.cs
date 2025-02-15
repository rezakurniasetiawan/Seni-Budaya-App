using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hasil : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI name;

    // scroe and timer quiz
    [SerializeField] TextMeshProUGUI timerQuizText;
    [SerializeField] TextMeshProUGUI scoreQuizText;

    //score and timer memory
    [SerializeField] TextMeshProUGUI timerMemoryText;
    [SerializeField] TextMeshProUGUI scoreMemoryText;

    // score and timer tebak
    [SerializeField] TextMeshProUGUI timerTebakText;
    [SerializeField] TextMeshProUGUI scoreTebakText;

    void Start()
    {
        name.text = "Hasil Nilai " + PlayerPrefs.GetString("name");
        timerQuizText.text = PlayerPrefs.GetString("quizTimer");
        scoreQuizText.text = PlayerPrefs.GetInt("quizSkor").ToString();

        timerMemoryText.text = PlayerPrefs.GetString("memoryTimer");
        scoreMemoryText.text = Mathf.Floor(PlayerPrefs.GetFloat("memorySkor")).ToString();

        timerTebakText.text = PlayerPrefs.GetString("tebakTimer");
        scoreTebakText.text = PlayerPrefs.GetInt("tebakSkor").ToString();
    }
}
