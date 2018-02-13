using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class ActiveDialogueManager : MonoBehaviour {


    public GameObject playerDialoguePanel;
    public GameObject npcDialoguePanel;
    public Button[] dialogueButtons;
    
    private Text npcText;
    private bool isTalking;
    private FirstPersonController fpsController;

    private void Awake() {
        fpsController = FindObjectOfType<FirstPersonController>();
    }
    private void Start() {
        npcText = npcDialoguePanel.GetComponentInChildren<Text>();
        isTalking = false;
    }
    public void StartDialogue() {
        FreezeScene();
        
        isTalking = true;
       
        npcText.text = DialogueTable.PickRandomGreeting();
        
        int ran1 = Random.Range(0, DialogueTable.choicesGood.Capacity-1);
        dialogueButtons[0].GetComponentInChildren<Text>().text = DialogueTable.choicesGood[ran1];
        int ran2 = Random.Range(0, DialogueTable.choicesBad.Capacity-1);
        dialogueButtons[1].GetComponentInChildren<Text>().text = DialogueTable.choicesBad[ran2];
    }
    public void NPC_ResponseToGood() {
        PlayerNotoriety.IncreasePlayerNotoriety();
        npcText.text = DialogueTable.PickRandomResponse();
        isTalking = false;
        UnFreezeScene();
    }
    public void NPC_ResponseToBad() {
        PlayerNotoriety.DecreasePlayerNotoriety();
        npcText.text = DialogueTable.PickRandomResponse();
        isTalking = false;
        UnFreezeScene();
    }
    public bool IsDialogueComplete() {
        return isTalking;
    }
    private void FreezeScene() {
        fpsController.enabled = !fpsController.isActiveAndEnabled;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = !Cursor.visible;
    }
    public void UnFreezeScene() {
        fpsController.enabled = !fpsController.isActiveAndEnabled;
        Time.timeScale = 1;
        Cursor.visible = !Cursor.visible;
        Cursor.lockState = CursorLockMode.Locked;        
    }
}