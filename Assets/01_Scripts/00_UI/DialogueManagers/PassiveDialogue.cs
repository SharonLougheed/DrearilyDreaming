using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]

public class PassiveDialogue : MonoBehaviour {

    
    public GameObject dialogueUIPrefab;
    public float prefabDelayTime;
    private float distanceAboveHead;

    //private Transform mainCameraTransform;
    private bool isTalking;
    private float thingy;
   

    private void Awake() {
        //mainCameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        distanceAboveHead = GetComponent<Mesh>().bounds.extents.y + 2f;
    }
    private void Start() {
        isTalking = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player") && isTalking == false && gameObject.name != "JOE")
        {
            StartCoroutine(PopupDialogue());
        }
        if (other.gameObject.CompareTag("Player") && isTalking == false && gameObject.name == "JOE")
        {
            StartCoroutine(JoePopup());
        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag("Player") && isTalking == false && gameObject.name != "JOE")
        {
            StartCoroutine(PopupDialogue());
        }
        if (other.gameObject.CompareTag("Player") && isTalking == false && gameObject.name == "JOE")
        {
            StartCoroutine(JoePopup());
        }
    }

    private IEnumerator JoePopup() {
        isTalking = true;
        GameObject newDialouge = Instantiate(dialogueUIPrefab, transform.position + (Vector3.up * distanceAboveHead), Quaternion.identity) as GameObject;

        newDialouge.GetComponent<DialogueUIManager>().SetDialogueText("Where have you been?\nI've been looking for you everywhere!");
        newDialouge.GetComponent<DialogueUIManager>().SetTransformToFollow(transform);
        newDialouge.GetComponent<DialogueUIManager>().SetDistanceAbovehead(distanceAboveHead);

        yield return new WaitForSeconds(prefabDelayTime);

        isTalking = false;
        Destroy(newDialouge);
    }

    private IEnumerator PopupDialogue() {
        isTalking = true;
        GameObject newDialouge = Instantiate(dialogueUIPrefab, transform.position + (Vector3.up * distanceAboveHead), Quaternion.identity) as GameObject;

        newDialouge.GetComponent<DialogueUIManager>().SetDialogueText(DialogueTable.PickRandomPassive());
        newDialouge.GetComponent<DialogueUIManager>().SetTransformToFollow(transform);
        newDialouge.GetComponent<DialogueUIManager>().SetDistanceAbovehead(distanceAboveHead);

        yield return new WaitForSeconds(prefabDelayTime);

        isTalking = false;
        Destroy(newDialouge);
    }
}
