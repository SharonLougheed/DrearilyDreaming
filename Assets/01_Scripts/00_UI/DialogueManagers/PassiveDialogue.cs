﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveDialogue : MonoBehaviour {

    public GameObject dialogueUIPrefab;
    public float prefabDelayTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(PopupDialogue());
        }
    }

    private IEnumerator PopupDialogue()
    {
        GameObject newDialouge = Instantiate(dialogueUIPrefab, transform.position + Vector3.up, Quaternion.identity);
        yield return new WaitForSeconds(prefabDelayTime);
        Destroy(newDialouge);
    }
}
