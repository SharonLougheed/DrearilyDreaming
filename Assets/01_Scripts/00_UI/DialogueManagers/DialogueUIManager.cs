using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUIManager : MonoBehaviour {

    //text file with dialogue pre-written
    //public TextAsset dialogueFile;
    //private string[] textLines;
    //private int lineNumber;
    private Transform mainCameraTransform;
    //child text ui object
    private Text dialogueTextChild;
    private Transform parentTransform;

    private void Awake() {
        dialogueTextChild = GetComponentInChildren<Text>();
        mainCameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    private void Update() {
        gameObject.transform.position = parentTransform.position + (Vector3.up * 1.5f);
        gameObject.transform.LookAt(mainCameraTransform.position);
    }
    public void SetTransformToFollow(Transform t) {
        parentTransform = t;
    }
    public void SetDialogueText(string s) {
        dialogueTextChild.text = s;
    }
}
