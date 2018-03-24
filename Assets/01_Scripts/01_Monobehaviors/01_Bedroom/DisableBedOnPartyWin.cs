using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBedOnPartyWin : MonoBehaviour {

    //private INTERACTABLE _script;
    [SerializeField] private END_PARTY_STATE objectState;

    //private void Awake() {
    //    //_script = GetComponent<INTERACTABLE>();
    //}

    // Use this for initialization
    private void Start () {
        objectState = GameManager.instance.data.endPartyState;
        switch (objectState)
        {
            case END_PARTY_STATE.WIN:
                GetComponent<INTERACTABLE>().enabled = false;
                break;
            case END_PARTY_STATE.LOSE:
                GetComponent<INTERACTABLE>().enabled = false;
                break;
            default:
                GetComponent<INTERACTABLE>().enabled = true;
                break;
        }
	}
}
