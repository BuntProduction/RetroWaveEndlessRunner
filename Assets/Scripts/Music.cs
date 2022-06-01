using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    static Music instance = null;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }
    public void ToggleSound()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
            //AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Muted", 1) == 1)
        {
            PlayerPrefs.SetInt("Muted", 0);
            //AudioListener = 0;
        }
        else{
            PlayerPrefs.SetInt("Muted", 1);
        }

    }
}
