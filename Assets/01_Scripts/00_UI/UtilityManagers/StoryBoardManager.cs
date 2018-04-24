using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryBoardManager : MonoBehaviour {

    public GameObject goodEnding, badEnding;

    [SerializeField] private END_PARTY_STATE objectState;

    private void Awake() {
        objectState = GameManager.instance.data.endPartyState;
    }

    // Use this for initialization
    private void Start () {
        switch (objectState)
        {
            case END_PARTY_STATE.DEFAULT:
                goodEnding.SetActive(false);
                badEnding.SetActive(false);
                break;
            case END_PARTY_STATE.WIN:
                goodEnding.SetActive(true);
                break;
            case END_PARTY_STATE.LOSE:
                badEnding.SetActive(true);
                break;
        }
	}
}