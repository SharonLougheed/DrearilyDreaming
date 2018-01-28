/*This script is a modular press a button to activate script*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButtonToActivate : MonoBehaviour {

    [Tooltip("Any PressTo... UI Object")] public GameObject pressToActivateText;

    private void Start() {
        pressToActivateText.SetActive(false);       //start with the 
    }
    
    private void OnTriggerEnter(Collider other)
    {    
        if (other.gameObject.CompareTag("Player"))
        {
            pressToActivateText.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //int randomDreamIndex = Random.RandomRange(2,4);   //this is the line to pick a dream at random
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            pressToActivateText.SetActive(false);
        }
    }
}
