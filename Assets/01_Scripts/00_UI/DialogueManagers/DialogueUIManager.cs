using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUIManager : MonoBehaviour {
    
    //text file with dialogue pre-written
    //public TextAsset dialogueFile;

    //child text ui object
    private Text dialogueTextChild;
    
    private void Awake()
    {
        dialogueTextChild = GetComponentInChildren<Text>();
    }
    //private void Start()
    //{
    //    dialogueTextChild.text = dialogueFile.text;
    //}
}
