﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RESTART : MonoBehaviour 
{

	// Update is called once per frame
	void Update () 
	{
		if ( Input.GetKeyDown ( KeyCode.Escape ) )
		{
			SceneManager.LoadScene ( 0 );
		}
	}

}
