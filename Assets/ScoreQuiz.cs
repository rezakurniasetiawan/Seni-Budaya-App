using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreQuiz : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI keterangan;



    void Start()
    {
        timerText.text = PlayerPrefs.GetString("quizTimer");
        scoreText.text = PlayerPrefs.GetInt("quizSkor").ToString();

        if (PlayerPrefs.GetInt("quizSkor") >= 80)
        {
            keterangan.text = "Kamu Hebat !";
        }
        else
        {
            keterangan.text = "Belajar lagi yaa...";
        }
    }
}
