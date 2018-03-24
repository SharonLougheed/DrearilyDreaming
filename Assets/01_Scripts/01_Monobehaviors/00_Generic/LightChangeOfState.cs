using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightChangeOfState : MonoBehaviour {
    private Light lampLight;

    [SerializeField] private END_PARTY_STATE objectState;

    private void Awake() {
        lampLight = GetComponent<Light>();
    }

    // Use this for initialization
    private void Start()
    {
        objectState = GameManager.instance.data.endPartyState;
        switch (objectState)
        {
            case END_PARTY_STATE.WIN:
                lampLight.intensity = .9f;
                lampLight.color = Color.Lerp(lampLight.color, 
                                        new Color(lampLight.color.r + 20f, lampLight.color.g+10f, lampLight.color.b),
                                        Time.deltaTime);
                break;
            case END_PARTY_STATE.LOSE:
                lampLight.intensity = .3f;
                lampLight.color = Color.Lerp(lampLight.color,
                                        new Color(lampLight.color.r - 20f, lampLight.color.g, lampLight.color.b),
                                        Time.deltaTime);
                break;
        }
    }
}