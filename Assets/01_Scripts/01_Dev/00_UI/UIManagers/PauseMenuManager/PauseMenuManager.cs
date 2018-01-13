using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityStandardAssets.Characters.FirstPerson;

public class PauseMenuManager : MonoBehaviour {

    public GameObject pauseMenuBackground,
                      pauseMenu;        //pause panel menu reference
    //public GameObject settingsMenu;     //settings panel menu reference                     
    //public GameObject gamePlayMusic;    //music object reference
    public AudioMixerSnapshot paused,   //mixer paused snapshot
                              unpaused; //mixer unpause snapshot
    [HideInInspector] public bool isPaused;        //boolean available to the entire game to determine if the game is paused or not

    private FirstPersonController firstPersonController;

    private void Awake() {
        isPaused = false;
        if (GameObject.FindGameObjectWithTag("GameController") != null)
        {
            GameObject tempObj = GameObject.FindGameObjectWithTag("GameController");
            firstPersonController = tempObj.GetComponent<FirstPersonController>();
        }
    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
        {
            //settingsMenu.SetActive(!settingsMenu.activeInHierarchy);
            Pause();
        }
    }
    void LowPass() {
        if (Time.timeScale == 0)
        {
            //transition to Paused Snapshot within the mixer
            paused.TransitionTo(0.01f);
        }
        else
        {
            //transition to Unpaused Snapshot with the mixer
            unpaused.TransitionTo(0.01f);
        }
    }
    public void Pause() {
        pauseMenuBackground.SetActive(!pauseMenuBackground.activeInHierarchy);      //turn on/off menu background
        pauseMenu.SetActive(!pauseMenu.activeInHierarchy);                          //turn on/off menu
        if (firstPersonController != null)
        {
            firstPersonController.enabled = !firstPersonController.isActiveAndEnabled;                                      //turn on/off the controller
            Cursor.visible = !Cursor.visible;
        }
        isPaused = !isPaused;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        LowPass();
    }
}