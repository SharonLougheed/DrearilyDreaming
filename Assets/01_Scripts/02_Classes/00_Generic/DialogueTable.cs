using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTable : MonoBehaviour{
    
    //Game dialogue text file assets
    public TextAsset passiveTextFile,
                     activeTextFile;
    
    //Passive dialogue lists
    [HideInInspector] public static List<string> badNearPassive = new List<string>(),
                                                 badMidPassive = new List<string>(),
                                                 badFarPassive = new List<string>(),
                                                 neutralNearPassive = new List<string>(),
                                                 neutralMidPassive = new List<string>(),
                                                 neutralFarPassive = new List<string>(),
                                                 goodNearPassive = new List<string>(),
                                                 goodMidPassive = new List<string>(),
                                                 goodFarPassive = new List<string>();
    //Active converstation Lists
    [HideInInspector] public static List<string> greetingsGood = new List<string>(),
                                                 greetingsNeutral = new List<string>(),
                                                 greetingsBad = new List<string>(),                                                 
                                                 choicesGood = new List<string>(),
                                                 choicesNeutral = new List<string>(),
                                                 choicesBad = new List<string>(),
                                                 responsesGood = new List<string>(),
                                                 responsesNeutral = new List<string>(),
                                                 responsesBad = new List<string>();

    [Tooltip("Adjusts what the NPCs pop up based on the distance to the target NPC")]
    public float nearDistance, midDistance;        //adjusts what the NPCs pop up based on the distance to the target NPC
    [Tooltip("Adjust what the NPCs pop up based on Player Notoriety")]
    public float goodRange, badRange;    //adjust what the NPCs pop up based on Player Notoriety

    private static float near, mid, good, bad;

    private void Awake() {
        //load text from file into Lists
        if (LoadPassiveTextAssets() && LoadActiveTextAssets())
        {            
            //Debug.Log("Asset Loading Complete");
        }
    }

    private void Start() {
        near = nearDistance;
        mid = midDistance;
        good = goodRange;
        bad = badRange;
    }

    private bool LoadPassiveTextAssets() {
        //load file and store to string        
        string passiveText = passiveTextFile.text;

        //parse string into array of strings
        string[] eachPassiveLine = passiveText.Split('\n');

        //loop through array and parse each line
        foreach(string line in eachPassiveLine)
        {
            //split the line
            string[] splitLine = line.Split('_');
            //switch on the 0 index
            string notoriety = splitLine[0];    //morality
            string temp,distance;
            switch(notoriety)
            {
                case "bad":
                    distance = splitLine[1];        //distance to target npc
                    switch(distance)
                    {
                        case "near":
                            temp = splitLine[2];
                            badNearPassive.Add(temp);
                            break;
                        case "mid":
                            temp = splitLine[2];
                            badMidPassive.Add(temp);
                            break;
                        case "far":
                            temp = splitLine[2];
                            badFarPassive.Add(temp);
                            break;
                        default:
                            Debug.Log("Loading to data structure failed! *BUGGED*");
                            return false;
                    }
                    //Debug.Log("badPassive's size is: " + badPassive.Capacity.ToString());
                    break;
                case "neutral":
                    distance = splitLine[1];
                    switch (distance)
                    {
                        case "near":
                            temp = splitLine[2];
                            neutralNearPassive.Add(temp);
                            break;
                        case "mid":
                            temp = splitLine[2];
                            neutralMidPassive.Add(temp);
                            break;
                        case "far":
                            temp = splitLine[2];
                            neutralFarPassive.Add(temp);
                            break;
                        default:
                            Debug.Log("Loading to data structure failed! *BUGGED*");
                            return false;
                    }           //distance to target npc
                    //Debug.Log("neutralPassive's size is: " + neutralPassive.Capacity.ToString());
                    break;
                case "good":
                    distance = splitLine[1];
                    switch (distance)
                    {
                        case "near":
                            temp = splitLine[2];
                            goodNearPassive.Add(temp);
                            break;
                        case "mid":
                            temp = splitLine[2];
                            goodMidPassive.Add(temp);
                            break;
                        case "far":
                            temp = splitLine[2];
                            goodFarPassive.Add(temp);
                            break;
                        default:
                            Debug.Log("Loading to data structure failed! *BUGGED*");
                            return false;
                    }           //distance to target npc
                    //Debug.Log("goodPassive's size is: " + goodPassive.Capacity.ToString());
                    break;
                default:
                    Debug.Log("Loading to data structure failed! *BUGGED*");
                    return false;
            }
        }
        return true;
    }
    private bool LoadActiveTextAssets() {
        //load file and store to string
        string activeText = activeTextFile.text;

        //parse string into array of strings
        string[] eachActiveLine = activeText.Split('\n');

        //loop through array and parse each line
        foreach (string line in eachActiveLine)
        {
            //split the line
            string[] splitLine = line.Split('_');

            //switch on index 0
            string convoLevel = splitLine[0];
            string temp, morality;
            switch (convoLevel)
            {
                case "greeting":
                    morality = splitLine[1];    //switch on index 1
                    switch(morality)
                    {
                        case "good":
                            temp = splitLine[2];    //add index 2 to list
                            greetingsGood.Add(temp);
                            //Debug.Log(temp + " (Was added)");
                            break;
                        case "neutral":
                            temp = splitLine[2];
                            greetingsNeutral.Add(temp);
                            //Debug.Log(temp + " (Was added)");
                            break;
                        case "bad":
                            temp = splitLine[2];
                            greetingsBad.Add(temp);
                            //Debug.Log(temp + " (Was added)");
                            break;
                        default:
                            Debug.Log("Loading to data structure failed!" + convoLevel +" " + morality + " " + splitLine[2] + " *BUGGED*");
                            return false;                            
                    }
                    break;
                case "choice":
                    morality = splitLine[1];
                    switch (morality)
                    {
                        case "good":
                            temp = splitLine[2];
                            choicesGood.Add(temp);
                            //Debug.Log(temp + " (Was added)");
                            break;
                        case "neutral":
                            temp = splitLine[2];
                            choicesNeutral.Add(temp);
                            //Debug.Log(temp + " (Was added)");
                            break;
                        case "bad":
                            temp = splitLine[2];
                            choicesBad.Add(temp);
                            //Debug.Log(temp + " (Was added)");
                            break;
                        default:
                            Debug.Log("Loading to data structure failed! *BUGGED*");
                            return false;
                    }
                    break;
                case "response":
                    morality = splitLine[1];
                    switch (morality)
                    {
                        case "good":
                            temp = splitLine[2];
                            responsesGood.Add(temp);
                            //Debug.Log(temp + " (Was added)");
                            break;
                        case "neutral":
                            temp = splitLine[2];
                            responsesNeutral.Add(temp);
                            //Debug.Log(temp + " (Was added)");
                            break;
                        case "bad":
                            temp = splitLine[2];
                            responsesBad.Add(temp);
                            //Debug.Log(temp + " (Was added)");
                            break;
                        default:
                            //Debug.Log("Loading to data structure failed! *BUGGED*");
                            return false;
                    }
                    break;
                default:
                    Debug.Log("Loading to data structure failed! *BUGGED*");
                    return false;
            }
        }
        return true;
    }
    public static string PickRandomPassive() {
        float playerNotoriety = PlayerNotoriety.GetPlayerNotoriety();
        string temp = "*REALLY BUGGED*";

        if (playerNotoriety >= good)      //good
        {
            int randomIndex;
            if(DistanceToTarget.distanceToTarget <= near)        //near
            {
                randomIndex = Random.Range(0, goodNearPassive.Count);
                temp = goodNearPassive[randomIndex];
                //Debug.Log("A Good thing was said");
                return temp;
            }
            else if(DistanceToTarget.distanceToTarget <= mid)   //mid
            {
                randomIndex = Random.Range(0, goodMidPassive.Count);
                temp = goodMidPassive[randomIndex];
                //Debug.Log("A Good thing was said");
                return temp;
            }
            else if(DistanceToTarget.distanceToTarget > mid)    //far
            {
                randomIndex = Random.Range(0, goodFarPassive.Count);
                temp = goodFarPassive[randomIndex];
                //Debug.Log("A Good thing was said");
                return temp;
            }
            else
            {
                //Debug.Log("Why is this happening?");
                temp = "*DEBUG ME!!*";
                return temp;
            }
        }
        else if (playerNotoriety <= bad)    //bad
        {
            int randomIndex;
            if (DistanceToTarget.distanceToTarget <= near)        //near
            {
                randomIndex = Random.Range(0,badNearPassive.Count);
                temp = badNearPassive[randomIndex];
                //Debug.Log("A Bad thing was said");
                return temp;
            }
            else if (DistanceToTarget.distanceToTarget <= mid)   //mid
            {
                randomIndex = Random.Range(0, badMidPassive.Count);
                temp = badMidPassive[randomIndex];
                //Debug.Log("A Bad thing was said");
                return temp;
            }
            else if (DistanceToTarget.distanceToTarget > mid)    //far
            {
                randomIndex = Random.Range(0, badFarPassive.Count);
                temp = badFarPassive[randomIndex];
                //Debug.Log("A Bad thing was said");
                return temp;
            }
            else
            {
                //Debug.Log("Why is this happening?");
                temp = "*DEBUG ME!!*";
                return temp;
            }
        }
        else if(playerNotoriety > bad && playerNotoriety < good)  //neutral
        {
            int randomIndex;
            if (DistanceToTarget.distanceToTarget <= near)        //near
            {
                randomIndex = Random.Range(0, goodNearPassive.Count);
                temp = goodNearPassive[randomIndex];
                //Debug.Log("A Neutral thing was said");
                return temp;
            }
            else if (DistanceToTarget.distanceToTarget <= mid)   //mid
            {
                randomIndex = Random.Range(0, goodMidPassive.Count);
                temp = goodMidPassive[randomIndex];
                //Debug.Log("A Neutral thing was said");
                return temp;
            }
            else if (DistanceToTarget.distanceToTarget > mid)    //far
            {
                randomIndex = Random.Range(0, goodFarPassive.Count);
                temp = goodFarPassive[randomIndex];
                //Debug.Log("A Neutral thing was said");
                return temp;
            }
            else
            {
                //Debug.Log("Why is this happening?");
                temp = "*DEBUG ME!!*";
                return temp;
            }
        }
        else
        {
            temp = "*DEBUG ME!!*";
            return temp;
        }
    }
    public static string PickRandomGreeting() {
        float playerNotoriety = PlayerNotoriety.GetPlayerNotoriety();
        string temp;

        if (playerNotoriety >= 5f)
        {
            int randomIndex = Random.Range(0, greetingsGood.Count-1);
            temp = greetingsGood[randomIndex];
            return temp;
        }
        else if (playerNotoriety <= -5f)
        {
            int randomIndex = Random.Range(0, greetingsBad.Count-1);
            temp = greetingsBad[randomIndex];
            return temp;
        }
        else if (playerNotoriety > -5f && playerNotoriety < 5f)
        {
            int randomIndex = Random.Range(0, greetingsNeutral.Count-1);
            temp = greetingsNeutral[randomIndex];
            return temp;
        }
        else
        {
            temp = "*DEBUG ME!!*";
            return temp;
        }
    }
    public static string PickRandomResponse() {
        float playerNotoriety = PlayerNotoriety.GetPlayerNotoriety();
        string temp;

        if (playerNotoriety >= 5f)
        {
            int randomIndex = Random.Range(0, responsesGood.Count);
            temp = responsesGood[randomIndex];
            return temp;
        }
        else if (playerNotoriety <= -5f)
        {
            int randomIndex = Random.Range(0, responsesBad.Count);
            temp = responsesBad[randomIndex];
            return temp;
        }
        else if (playerNotoriety > -5f && playerNotoriety < 5f)
        {
            int randomIndex = Random.Range(0, responsesNeutral.Count);
            temp = responsesNeutral[randomIndex];
            return temp;
        }
        else
        {
            temp = "*DEBUG ME!!*";
            return temp;
        }
    }
}