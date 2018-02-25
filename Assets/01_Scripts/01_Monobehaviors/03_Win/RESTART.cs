using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RESTART : MonoBehaviour 
{

	void Start ()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	// Update is called once per frame
	void Update () 
	{
		if ( Input.GetKeyDown ( KeyCode.Escape ) )
		{
			SceneManager.LoadScene ( 0 );
		}
	}

}
