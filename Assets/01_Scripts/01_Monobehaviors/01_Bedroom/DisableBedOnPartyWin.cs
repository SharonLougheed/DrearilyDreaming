using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBedOnPartyWin : MonoBehaviour {

    [SerializeField] private END_PARTY_STATE objectState;

    private INTERACTABLE _bed;

    private void Awake()
    {
        _bed = gameObject.GetComponent<INTERACTABLE>();
    }

    // Use this for initialization
    private void Start () {
        objectState = GameManager.instance.data.endPartyState;
        Debug.Log("Object State:\t" + objectState.ToString());
        switch (objectState)
        {
            case END_PARTY_STATE.WIN:
                _bed.enabled = false;
                break;
            case END_PARTY_STATE.LOSE:
                _bed.enabled = false;
                break;
            default:
                _bed.enabled = true;
                break;
        }
	}
}
