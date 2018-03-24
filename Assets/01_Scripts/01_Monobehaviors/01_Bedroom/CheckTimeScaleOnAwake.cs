using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTimeScaleOnAwake : MonoBehaviour {

    private void Awake() {
        if (Time.timeScale != 1f) Time.timeScale = 1f;
    }
}
