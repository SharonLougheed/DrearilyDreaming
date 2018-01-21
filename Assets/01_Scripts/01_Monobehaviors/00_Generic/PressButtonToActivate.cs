/*This script is a modular press a button to activate script*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButtonToActivate : MonoBehaviour {

    [Tooltip("Any PressTo... UI Object")] public GameObject pressToActivateText;
    [HideInInspector] public static bool playerInRange;

    private void Start() {
        pressToActivateText.SetActive(false);
        playerInRange = false;
    }

    private void OnTriggerEnter(Collider other)
    {    
        if (other.gameObject.CompareTag("Player"))
        {
            pressToActivateText.SetActive(true);
            playerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            pressToActivateText.SetActive(false);
            playerInRange = false;
        }
    }
}
