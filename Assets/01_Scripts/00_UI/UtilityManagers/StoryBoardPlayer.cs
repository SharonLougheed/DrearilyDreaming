using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryBoardPlayer : MonoBehaviour {

    public GameObject pauseMenuManager;
    public float storyboardViewTime;
    public List<GameObject> storyBoards = new List<GameObject>();

    private int currentBoard;

    private void Awake() {
        pauseMenuManager.GetComponent<PauseMenuManager>().enabled = false;
        currentBoard = 0;
        foreach (GameObject o in storyBoards)
        {
            o.SetActive(false);
        }
    }

    // Use this for initialization
    void Start () {
        //Image _foreground = GameObject.Find("LoadScreenImage").GetComponent<Image>();
        //if (_foreground.color.a <= 0f)
        InvokeRepeating("StoryTeller",0f, storyboardViewTime);
	}

    void StoryTeller() {
        if (currentBoard < storyBoards.Count)
        {
            storyBoards[currentBoard].SetActive(true);
            currentBoard++;
        }
        else
        {
            CancelInvoke();
            gameObject.SetActive(false);
            pauseMenuManager.GetComponent<PauseMenuManager>().enabled = true;
        }
    }
}
