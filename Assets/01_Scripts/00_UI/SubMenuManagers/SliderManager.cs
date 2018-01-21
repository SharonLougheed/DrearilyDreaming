using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SliderManager : MonoBehaviour {

    public AudioMixer mixer;    //outside mixer object to change the value    
    public Slider[] allSliders; //this game objects slider component

    private void Awake() {
        LoadValues();
    }
    public void SetMasterVolume() {
        mixer.SetFloat("masterVolume", allSliders[0].value);
        PlayerPrefs.SetFloat("MasterVolume", allSliders[0].value);
    }
    public void SetMusicVolume() {
        mixer.SetFloat("musicVolume", allSliders[1].value);
        PlayerPrefs.SetFloat("MusicVolume", allSliders[1].value);
    }
    public void SetUIVolume() {
        mixer.SetFloat("uiVolume", allSliders[2].value);
        PlayerPrefs.SetFloat("UIVolume", allSliders[2].value);
    }
    public void SetFXVolume() {
        mixer.SetFloat("fxVolume", allSliders[3].value);
        PlayerPrefs.SetFloat("FXVolume", allSliders[3].value);
    }
    public void ResetAudio() {
        for(int i = 0; i < allSliders.Length; i++)
        {
            allSliders[i].value = 0f;
        }
        mixer.SetFloat("masterVolume", 0f);
        PlayerPrefs.SetFloat("MasterVolume", 0f);
        mixer.SetFloat("musicVolume", 0f);
        PlayerPrefs.SetFloat("MusicVolume", 0f);
        mixer.SetFloat("uiVolume", 0f);
        PlayerPrefs.SetFloat("UIVolume", 0f);
        mixer.SetFloat("fxVolume", 0f);
        PlayerPrefs.SetFloat("FXVolume", 0f);
    }
    private void LoadValues() {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            allSliders[0].value = PlayerPrefs.GetFloat("MasterVolume");
            mixer.SetFloat("masterVolume", PlayerPrefs.GetFloat("MasterVolume"));
        }
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            allSliders[1].value = PlayerPrefs.GetFloat("MusicVolume");
            mixer.SetFloat("musicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        }
        if (PlayerPrefs.HasKey("UIVolume"))
        {
            allSliders[2].value = PlayerPrefs.GetFloat("UIVolume");
            mixer.SetFloat("uiVolume", PlayerPrefs.GetFloat("UIVolume"));
        }
        if (PlayerPrefs.HasKey("FXVolume"))
        {
            allSliders[3].value = PlayerPrefs.GetFloat("FXVolume");
            mixer.SetFloat("fxVolume", PlayerPrefs.GetFloat("FXVolume"));
        }
    }
}
