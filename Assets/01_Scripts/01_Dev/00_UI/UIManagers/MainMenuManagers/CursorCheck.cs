using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorCheck : MonoBehaviour {
	void Start () {
        if (Cursor.visible == false) Cursor.visible = true;
	}
}
