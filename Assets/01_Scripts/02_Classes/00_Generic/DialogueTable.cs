using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTable : MonoBehaviour{
    
    //Game dialogue text file assets
    public TextAsset passiveTextFile,
                     activeTextFile;
    
    //Passive dialogue lists
    [HideInInspector] public static List<string> badPassive = new List<string>(),
                                                 neutralPassive = new List<string>(),
                                                 goodPassive = new List<string>();
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
    private void Awake() {
        //load text from file into Lists
        if (LoadPassiveTextAssets() && LoadActiveTextAssets())
        {            
            Debug.Log("Asset Loading Complete");
        }
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
            string notoriety = splitLine[0];
            string temp;
            switch(notoriety)
            {
                case "bad":
                    temp = splitLine[1];
                    badPassive.Add(temp);
                    //Debug.Log("badPassive's size is: " + badPassive.Capacity.ToString());
                    break;
                case "neutral":
                    temp = splitLine[1];
                    neutralPassive.Add(temp);
                    //Debug.Log("neutralPassive's size is: " + neutralPassive.Capacity.ToString());
                    break;
                case "good":
                    temp = splitLine[1];
                    goodPassive.Add(temp);
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
                            break;
                        case "neutral":
                            temp = splitLine[2];
                            greetingsNeutral.Add(temp);
                            break;
                        case "bad":
                            temp = splitLine[2];
                            greetingsBad.Add(temp);
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
                            break;
                        case "neutral":
                            temp = splitLine[2];
                            choicesNeutral.Add(temp);
                            break;
                        case "bad":
                            temp = splitLine[2];
                            choicesBad.Add(temp);
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
                            break;
                        case "neutral":
                            temp = splitLine[2];
                            responsesNeutral.Add(temp);
                            break;
                        case "bad":
                            temp = splitLine[2];
                            responsesBad.Add(temp);
                            break;
                        default:
                            Debug.Log("Loading to data structure failed! *BUGGED*");
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
        int playerNotoriety = PlayerNotoriety.GetPlayerNotoriety();
        string temp;

        if (playerNotoriety >= 5)
        {
            int randomIndex = Random.Range(0, goodPassive.Count - 1);
            temp = goodPassive[randomIndex];
            return temp;
        }
        else if (playerNotoriety <= -5)
        {
            int randomIndex = Random.Range(0, badPassive.Count - 1);
            temp = badPassive[randomIndex];
            return temp;
        }
        else if(playerNotoriety > -5 && playerNotoriety < 5)
        {
            int randomIndex = Random.Range(0, neutralPassive.Count - 1);
            temp = neutralPassive[randomIndex];
            return temp;
        }
        else
        {
            temp = "*DEBUG ME!!*";
            return temp;
        }
    }
}