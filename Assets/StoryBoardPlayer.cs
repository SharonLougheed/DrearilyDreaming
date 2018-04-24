using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryBoardPlayer : MonoBehaviour {

    public List<GameObject> storyBoards = new List<GameObject>();

    private void Awake() {
        foreach(GameObject o in storyBoards)
        {
            o.SetActive(false);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
