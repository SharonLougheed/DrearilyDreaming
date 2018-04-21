using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour {

    public List<GameObject> _trash = new List<GameObject>();
    
    [SerializeField] private END_PARTY_STATE currentGameState;

    private void Awake() {

        GameManager _gm = GameManager.instance;

        currentGameState = _gm.data.endPartyState;
    }

    // Use this for initialization
    private void Start () {
        Debug.Log("End Game State:\t" + currentGameState.ToString());
        switch (currentGameState)
        {
            case END_PARTY_STATE.DEFAULT:
                foreach(GameObject t in _trash)
                {
                    t.SetActive(false);
                }
                break;
            case END_PARTY_STATE.WIN:
                foreach (GameObject t in _trash)
                {
                    t.SetActive(false);
                }
                break;
            case END_PARTY_STATE.LOSE:
                foreach (GameObject t in _trash)
                {
                    t.SetActive(true);
                }
                break;
        }
	}
}
