using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnKeyPress : MonoBehaviour {

    private void Update()
    {
        if (PressButtonToActivate.playerInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(2);  //scene with index 2 is the dance party scene
            PressButtonToActivate.playerInRange = false;
        }
    }
}
