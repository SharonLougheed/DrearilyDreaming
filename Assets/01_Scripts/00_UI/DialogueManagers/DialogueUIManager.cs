using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUIManager : MonoBehaviour {

    //public float heightAboveNPC;
    private Transform mainCameraTransform;    //main camera object
    private Text dialogueTextChild; //child text ui object
    private Transform parentTransform;        //transform of the parent gameObject to follow

    private void Awake() {
        dialogueTextChild = GetComponentInChildren<Text>();
        mainCameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    private void Update() {
        gameObject.transform.position = parentTransform.position + (Vector3.up * 2.5f);// heightAboveNPC);
        gameObject.transform.LookAt(mainCameraTransform.position);
    }
    public void SetTransformToFollow(Transform t) {
        parentTransform = t;
    }
    public void SetDialogueText(string s) {
        if (s.Equals(""))
        {
            dialogueTextChild.text = "*BUGGED-FIX ME*";
        }
        else
        {
            dialogueTextChild.text = s;
        }
    }
}
