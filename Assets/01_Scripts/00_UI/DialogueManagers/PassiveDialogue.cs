using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveDialogue : MonoBehaviour {

    
    public GameObject dialogueUIPrefab;
    public float prefabDelayTime;

    //private Transform mainCameraTransform;
    private bool isTalking;

    private void Awake() {
        //mainCameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    private void Start() {
        isTalking = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isTalking == false)
        {
            StartCoroutine(PopupDialogue());
            isTalking = true;
        }
    }

    private IEnumerator PopupDialogue() {
        GameObject newDialouge = Instantiate(dialogueUIPrefab, transform.position + Vector3.up, Quaternion.identity) as GameObject;
        newDialouge.GetComponent<DialogueUIManager>().SetDialogueText(DialogueTable.PickRandomPassive());
        newDialouge.GetComponent<DialogueUIManager>().SetTransformToFollow(gameObject.transform);
        yield return new WaitForSeconds(prefabDelayTime);
        isTalking = false;
        Destroy(newDialouge);
    }
}
