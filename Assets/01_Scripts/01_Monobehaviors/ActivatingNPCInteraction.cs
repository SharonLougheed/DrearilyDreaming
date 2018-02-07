using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatingNPCInteraction : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(gameObject.transform.position, Vector3.forward, 5.0f))
        {

        }
	}
}
