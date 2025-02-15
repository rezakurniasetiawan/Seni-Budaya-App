using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class InputName : MonoBehaviour
{
    public TMP_InputField inputField;

    public void SaveName()
    {
        PlayerPrefs.SetString("name", inputField.text);
        Debug.Log("Name: " + PlayerPrefs.GetString("name"));

        SceneManager.LoadScene("Home");
    }
}
