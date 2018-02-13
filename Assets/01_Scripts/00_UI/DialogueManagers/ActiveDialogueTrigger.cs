using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDialogueTrigger : MonoBehaviour {
    public ActiveDialogueManager dialogueManager;
    public GameObject talkText;
    public GameObject playerDialoguePanel;
    public GameObject npcDialoguePanel;
    public float talkingRange;

    [HideInInspector] public static bool isInteracting;
    private GameObject retical;

    private void Awake()
    {
        retical = GameObject.FindGameObjectWithTag("Retical");
        //cam = GetComponent<Camera>();
    }

    // Use this for initialization
    void Start () {
        talkText.SetActive(false);
        isInteracting = false;
    }
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(retical.transform.position);
        RaycastHit hit;

        //Debug.DrawRay(gameObject.transform.position,Vector3.forward,Color.blue);
        if(Physics.Raycast(ray,out hit, talkingRange))
        {
            Debug.DrawLine(ray.origin, hit.point);
            if (hit.collider.CompareTag("NPC"))
            {

                talkText.SetActive(true);
                Debug.Log("ray is hitting NPC");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    StartCoroutine(InitiateDialogue());
                }
            }
        }
        else
        {
            talkText.SetActive(false);
        }
	}
    private IEnumerator InitiateDialogue() {
        isInteracting = true;
        Debug.Log("BeginDialogue() is being called");
        playerDialoguePanel.SetActive(true);
        npcDialoguePanel.SetActive(true);
        dialogueManager.StartDialogue();

        yield return new WaitWhile(() => dialogueManager.IsDialogueComplete());

        StartCoroutine(WaitForAFewSeconds());
    }
    private IEnumerator WaitForAFewSeconds()
    {
        yield return new WaitForSeconds(3f);
        //dialogueManager.UnFreezeScene();
        playerDialoguePanel.SetActive(false);
        npcDialoguePanel.SetActive(false);
    }
}
