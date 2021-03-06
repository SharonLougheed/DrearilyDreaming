﻿//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
//#if UNITY_EDITOR
//using UnityEditor;
//#endif
using UnityStandardAssets.Characters.FirstPerson;
//using UnityStandardAssets.Characters.ThirdPerson;

public class PauseMenuManager : MonoBehaviour {

    public GameObject pauseMenuBackground,
                      pauseMenu;        //pause panel menu reference
    //public GameObject settingsMenu;     //settings panel menu reference                     
    //public GameObject gamePlayMusic;    //music object reference
    public AudioMixerSnapshot paused,   //mixer paused snapshot
                              unpaused; //mixer unpause snapshot
    [HideInInspector] public bool isPaused;        //boolean available to the entire game to determine if the game is paused or not

    private FirstPersonController firstPersonController;
    //private ThirdPersonCharacter thirdPersonCharacter;
    //private ThirdPersonUserControl thirdPersonUserControl;
	private CUSTOM_THIRD_PERSON_CONTROLLER customThirdPersonController;

    private void Awake() {       
        if (GameObject.FindGameObjectWithTag("GameController") != null)
        {
            GameObject tempController = GameObject.FindGameObjectWithTag("GameController");
            firstPersonController = tempController.GetComponent<FirstPersonController>();
        }
        if(GameObject.FindGameObjectWithTag("Player") != null)// && GameObject.FindGameObjectWithTag("Player"))
        {
            GameObject tempPlayer = GameObject.FindGameObjectWithTag("Player");
   //         thirdPersonCharacter = tempPlayer.GetComponent<ThirdPersonCharacter>();
			//thirdPersonUserControl = tempPlayer.GetComponent<ThirdPersonUserControl>();
			customThirdPersonController = tempPlayer.GetComponent <CUSTOM_THIRD_PERSON_CONTROLLER> ();
        }
    }
    private void Start() {
        isPaused = false;
		Cursor.visible = false;
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

        if (GameObject.FindGameObjectWithTag("GameController") != null)
        {
            firstPersonController.enabled = !firstPersonController.isActiveAndEnabled;                                      //turn on/off the controller
            if (Cursor.visible != true && Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = !Cursor.visible;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = true;
            }
        }
        else if(GameObject.FindGameObjectWithTag("Player") != null)// && GameObject.FindGameObjectWithTag("Player") != null)
        {
            //thirdPersonCharacter.enabled = !thirdPersonCharacter.isActiveAndEnabled;
			//thirdPersonUserControl.enabled = !thirdPersonUserControl.isActiveAndEnabled;
			customThirdPersonController.enabled = !customThirdPersonController.isActiveAndEnabled;
			Cursor.lockState = ( Cursor.lockState == CursorLockMode.Locked ) ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = !Cursor.visible;
        }

        isPaused = !isPaused;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        LowPass();
    }
}