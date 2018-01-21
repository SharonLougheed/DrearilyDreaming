using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMusicManager : MonoBehaviour {
    public static SoundMusicManager instance;
    public AudioClip[] allClips;

    private AudioSource source;

    private void Awake() {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        source = GetComponent<AudioSource>();
    }
    private void Start() {
        source.clip = allClips[0];
        source.Play();        
    }
    public void LoadLevelZeroMusic()
    {
        source.clip = allClips[0];
        source.Play();
    }
    public void LoadLevelOneMusic()
    {
        source.clip = allClips[1];
        source.Play();
    }
}
