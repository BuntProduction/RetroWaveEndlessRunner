using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundEffectsScript : MonoBehaviour
{
  
    private MusicEffects music;
    public Button musicToggleButton;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.FindObjectOfType<MusicEffects>();
        UpdateIcon();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseMusic()
    {
        music.ToggleSound();
        UpdateIcon();
    }
    void UpdateIcon()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            musicToggleButton.GetComponent<Image>().sprite = musicOnSprite;
        }
        else
        {
            AudioListener.volume = 0;
            musicToggleButton.GetComponent<Image>().sprite = musicOffSprite;
        }
    }/*
    public void PlaySound(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
                s.source.Play();
        }
    }*/
}
