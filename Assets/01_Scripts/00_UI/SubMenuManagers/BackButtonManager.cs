using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonManager : MonoBehaviour {

	public void Save() {
        PlayerPrefs.Save();
    }
}
