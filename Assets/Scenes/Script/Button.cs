using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void MenuBermain()
    {
        SceneManager.LoadScene("Bermain");
    }

    public void MenuBelajar()
    {
        SceneManager.LoadScene("Belajar");
    }

    public void MenuHasil()
    {
        SceneManager.LoadScene("Hasil");
    }

    public void BackHome()
    {
        SceneManager.LoadScene("Home");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MenuBelajarAlatMusik()
    {
        SceneManager.LoadScene("AlatMusik1");
    }

    public void MenuBelajarTarian()
    {
        SceneManager.LoadScene("Tarian1");
    }


    public void MenuBelaSeniRupa()
    {
        SceneManager.LoadScene("SeniRupa1");
    }

    public void MenuBermainTebak()
    {
        // reset score and timer
        PlayerPrefs.SetInt("tebakSkor", 0);
        PlayerPrefs.SetString("tebakTimer", "00:00");
        SceneManager.LoadScene("Tebak1");
    }
    public void MenuBermainQuiz()
    {
        // reset score and timer
        PlayerPrefs.SetInt("quizSkor", 0);
        PlayerPrefs.SetString("quizTimer", "00:00");
        SceneManager.LoadScene("Quiz1");
    }
    public void MenuBermainMemoryGame()
    {
        // reset score and timer
        PlayerPrefs.SetInt("memorySkor", 0);
        PlayerPrefs.SetString("memoryTimer", "00:00");
        SceneManager.LoadScene("MemoryGame");
    }


}
