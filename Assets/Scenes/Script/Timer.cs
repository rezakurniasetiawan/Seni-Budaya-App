using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI timerHiddenText;


    public string type;
    float elapsedTime;
    float elapsedTimeHidden = 300f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Timer naik dari 0 ke 300
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Timer turun dari 300 ke 0
        elapsedTimeHidden -= Time.deltaTime;
        elapsedTimeHidden = Mathf.Max(elapsedTimeHidden, 0); // Mencegah nilai negatif
        int minutesHidden = Mathf.FloorToInt(elapsedTimeHidden / 60);
        int secondsHidden = Mathf.FloorToInt(elapsedTimeHidden % 60);
        timerHiddenText.text = string.Format("{0:00}:{1:00}", minutesHidden, secondsHidden);
    }



    // set timer akhir ke playerprefs dengan format minutes:seconds
    public void setTimer()
    {
        if (type == "Tebak")
        {
            PlayerPrefs.SetString("tebakTimer", timerText.text);
            Debug.Log("End Timer: " + PlayerPrefs.GetString("tebakTimer"));
        }
    }
}
