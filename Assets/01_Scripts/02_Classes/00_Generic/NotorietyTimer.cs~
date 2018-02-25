using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotorietyTimer : MonoBehaviour {

    public float frequencyOfNotorietyIncrease;

    //private float timer;

    //// Use this for initialization
    //void Start()
    //{
    //    timer = 0f;
    //}

    // Update is called once per frame
    void Update()
    {
        float n = Mathf.Lerp(PlayerNotoriety.GetPlayerNotoriety(), 0f, frequencyOfNotorietyIncrease);

        if (n != 0f && Time.timeScale != 0f) //timer > frequencyOfNotorietyIncrease && Time.timeScale != 0f)
        {
            if (n < 0f)
            {
                PlayerNotoriety.IncreasePlayerNotoriety();
                //timer = 0f;
                //Debug.Log("Notoriety is going up.");
            }
            if(n > 0f)
            {
                PlayerNotoriety.DecreasePlayerNotoriety();
                //timer = 0f;
                //Debug.Log("Notoriety is going down.");
            }
        }
        else
        {
           // Debug.Log("notoriety is 0");
        }
        //timer += Time.deltaTime;
        
    }
}
