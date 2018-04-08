using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartManager : MonoBehaviour {

    public float noterietyValueToTrigger;

    private float localNoteriety;
    [SerializeField] private List<GameObject> bodyParts = new List<GameObject>();
    private bool isBodyParts;

    private void Start() {
        localNoteriety = PlayerNotoriety.GetPlayerNotoriety();
        foreach(GameObject body_part in bodyParts)
        {
            if(body_part.activeInHierarchy == true)
            {
                body_part.SetActive(false);
            }
        }
        isBodyParts = false;
    }
    
    private void Update () {
        localNoteriety = PlayerNotoriety.GetPlayerNotoriety();
        if (localNoteriety <= noterietyValueToTrigger && isBodyParts == false)
        {
            foreach (GameObject body_part in bodyParts)
            {
                if (body_part.activeInHierarchy == false)
                {
                    body_part.SetActive(true);
                }
            }
            isBodyParts = true;
        }
        if (localNoteriety > noterietyValueToTrigger && isBodyParts == true)
        {
            foreach (GameObject body_part in bodyParts)
            {
                if (body_part.activeInHierarchy == true)
                {
                    body_part.SetActive(false);
                }
            }
            isBodyParts = false;
        }
	}
}
