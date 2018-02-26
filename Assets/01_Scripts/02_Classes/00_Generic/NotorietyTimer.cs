using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotorietyTimer : MonoBehaviour {

    public float frequencyOfNotorietyIncrease;

    private float timer;

    // Use this for initialization
    void Start()
    {
        timer = frequencyOfNotorietyIncrease;
    }

    // Update is called once per frame
    void Update()
    {
        float n = PlayerNotoriety.GetPlayerNotoriety(); //Mathf.Lerp(PlayerNotoriety.GetPlayerNotoriety(), 0f, frequencyOfNotorietyIncrease);

        if (n != 0f && Time.timeScale != 0f) //timer > frequencyOfNotorietyIncrease && Time.timeScale != 0f)
        {
            timer -= Time.deltaTime;
            if (n < 0f && timer <= 0f)
            {
                PlayerNotoriety.IncreasePlayerNotoriety();
                timer = frequencyOfNotorietyIncrease;
                //Debug.Log("Notoriety is going up." + n.ToString());
            }
            else if(n > 0f && timer <= 0f)
            {
                PlayerNotoriety.DecreasePlayerNotoriety();
                timer = frequencyOfNotorietyIncrease;
                //Debug.Log("Notoriety is going down." + n.ToString());
            }
            else
            {
                //Debug.Log("Notoriety is 0");
            }
        }
        //else
        //{
        //}
            //Debug.Log("Notoriety:\t" + n.ToString());
    }
}
