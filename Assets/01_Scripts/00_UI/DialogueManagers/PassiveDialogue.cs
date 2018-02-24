using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveDialogue : MonoBehaviour {

    
    public GameObject dialogueUIPrefab;
    public float prefabDelayTime;
    public float distanceAboveHead;

    //private Transform mainCameraTransform;
    private bool isTalking;
    private float thingy;

    private void Awake() {
        //mainCameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
        
    }
    private void Start() {
        isTalking = false;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player") && isTalking == false)
        {
            StartCoroutine(PopupDialogue());
        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag("Player") && isTalking == false)
        {
            StartCoroutine(PopupDialogue());
        }
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
