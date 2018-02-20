using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIRROR : MonoBehaviour {

	public Camera cam;

	// Use this for initialization
	void Start () {
		Matrix4x4 mat = cam.projectionMatrix;
		mat *= Matrix4x4.Scale(new Vector3(1, -1, 1));
		cam.projectionMatrix = mat;
	}
}
