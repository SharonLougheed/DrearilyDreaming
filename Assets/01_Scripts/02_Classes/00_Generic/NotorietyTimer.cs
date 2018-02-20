using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotorietyTimer : MonoBehaviour {

    public float frequencyOfNotorietyIncrease;

    private float timer;

    // Use this for initialization
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > frequencyOfNotorietyIncrease && Time.timeScale != 0f)
        {
            PlayerNotoriety.IncreasePlayerNotoriety();
            timer = 0f;
        }
        timer += Time.deltaTime;
    }
}
