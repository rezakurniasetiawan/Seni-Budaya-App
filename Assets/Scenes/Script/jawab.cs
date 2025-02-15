using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class jawab : MonoBehaviour
{
    public GameObject benar, salah;
    [SerializeField] TextMeshProUGUI timerText;
    public string type;
    void Start()
    {

    }

    // update 
    void Update()
    {
        if (timerText.text == "05:00")
        {
            if (type == "Tebak")
            {
                PlayerPrefs.SetString("tebakTimer", timerText.text);
                SceneManager.LoadScene("ScoreTebak");
            }
            else if (type == "Quiz")
            {
                PlayerPrefs.SetString("quizTimer", timerText.text);
                SceneManager.LoadScene("ScoreQuiz");
            }
        }

    }

    public void jawaban(bool jawab)
    {
        if (jawab)
        {
            benar.SetActive(false);
            benar.SetActive(true);
            if (type == "Tebak")
            {
                int skor = PlayerPrefs.GetInt("tebakSkor") + 10;
                PlayerPrefs.SetInt("tebakSkor", skor);
            }
            else if (type == "Quiz")
            {
                int skor = PlayerPrefs.GetInt("quizSkor") + 10;
                PlayerPrefs.SetInt("quizSkor", skor);
            }
        }
        else
        {
            salah.SetActive(false);
            salah.SetActive(true);
        }
        gameObject.SetActive(false);
        transform.parent.GetChild(gameObject.transform.GetSiblingIndex() + 1).gameObject.SetActive(true);

        Debug.Log(gameObject.transform.GetSiblingIndex());

        if (gameObject.transform.GetSiblingIndex() == 11)
        {
            if (type == "Tebak")
            {

                PlayerPrefs.SetString("tebakTimer", timerText.text);
                SceneManager.LoadScene("ScoreTebak");
            }
            else if (type == "Quiz")
            {
                PlayerPrefs.SetString("quizTimer", timerText.text);
                SceneManager.LoadScene("ScoreQuiz");
            }
        }
    }

}