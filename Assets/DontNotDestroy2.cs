using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontNotDestroy2 : MonoBehaviour
{
    private void Awake()
    {

        // jika ada GameObject.FindGameObjectsWithTag("GameMusic"); replace dengan GameObject.FindGameObjectsWithTag("GameMusic2");
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic2");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

    }
}
