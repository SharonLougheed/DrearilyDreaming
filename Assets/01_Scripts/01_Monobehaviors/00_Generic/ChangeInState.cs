using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeInState : MonoBehaviour
{

    public GameObject objectToTransform;
    public Transform winState;
    public Transform loseState;

    [SerializeField] private END_PARTY_STATE objectState;

    private void Awake()
    {
        objectState = GameManager.instance.data.endPartyState;
    }
    // Use this for initialization
    private void Start()
    {
        switch (objectState)
        {
            case END_PARTY_STATE.WIN:
                objectToTransform.transform.SetPositionAndRotation(winState.position, winState.rotation);
                break;
            case END_PARTY_STATE.LOSE:
                objectToTransform.transform.SetPositionAndRotation(loseState.position, loseState.rotation);
                break;
        }
    }
}