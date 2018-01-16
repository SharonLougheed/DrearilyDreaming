﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {
	public void LoadByIndex(int sceneIndex) {
        Time.timeScale = 1f;
		CELL_MAP.cellInstances.Clear ();
        SceneManager.LoadScene(sceneIndex);
    }
}
