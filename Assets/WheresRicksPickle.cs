using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheresRicksPickle : MonoBehaviour {
    public GameObject thePickle;
    public Transform[] pickleSpawns;

	// Use this for initialization
	void Start () {
        int i = (int)Random.Range(0f, pickleSpawns.Length);
        thePickle.transform.SetPositionAndRotation(pickleSpawns[i].position,pickleSpawns[i].rotation);
	}
}
