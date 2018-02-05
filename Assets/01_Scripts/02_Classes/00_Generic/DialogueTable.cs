using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTable : MonoBehaviour{

    //list of all dialogue files for this class
    public TextAsset passiveTextFile;//,activeTextFile;

    [HideInInspector] public static List<string> badPassive = new List<string>(),
                                                 neutralPassive = new List<string>(),
                                                 goodPassive = new List<string>();

    private void Awake()
    {
        LoadTextAssets();   //load text from file into Lists
    }
    private void LoadTextAssets() {
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
                    break;
                case "neutral":
                    temp = splitLine[1];
                    neutralPassive.Add(temp);
                    break;
                case "good":
                    temp = splitLine[1];
                    goodPassive.Add(temp);
                    break;
                default:
                    Debug.Log("Loading to data structure failed! *BUGGED*");
                    break;
            }
        }
        /*
        //string[] eachActiveLine;
        //string activeText = activeTextFile.text;
        //eachActiveLine = activeText.Split('\n');
        
        //string[] eachLine;                  //array for storage of each full line of text from the file
        //string tempString = textFile.text;  //string variable to hold the data from the file
                        
        //eachLine = tempString.Split('\n');  //parse data into individual lines
        //foreach (string section in eachLine)    //parse each line into two sections; index 0: dictionary key. index 1: string for storage
        //{
        //    //formatting for the file should be "listkey_dialogue\n" ex. "passive answer_I am the real Slim Shady!"
        //    string[] splitLine = section.Split('_');    //split the line at the underscore
        //    string keyWord,dialogue;
        //    //switch (textFile.name)
        //    //{
        //    //    case "passiveAnswer":
        //    //        keyWord = splitLine[0];
        //    //        dialogue = splitLine[1];
        //    //        passiveAnswerList.Add(keyWord,dialogue);
        //    //        break;
        //    //    case "passiveQuestion":
        //    //        keyWord = splitLine[0];
        //    //        dialogue = splitLine[1];
        //    //        passiveQuestionList.Add(keyWord, dialogue);
        //    //        break;
        //    //    case "activeAnswer":
        //    //        keyWord = splitLine[0];
        //    //        dialogue = splitLine[1];
        //    //        activeAnswerList.Add(keyWord, dialogue);
        //    //        break;
        //    //    case "activeQuestion":
        //    //        keyWord = splitLine[0];
        //    //        dialogue = splitLine[1];
        //    //        activeQuestionList.Add(keyWord, dialogue);
        //    //        break;
        //    //    default:
        //    //        break;
        //    //}            
        //}
        */
    }
    public static string PickRandomPassive() {
        int playerNotoriety = PlayerNotoriety.GetPlayerNotoriety();
        string temp;

        if (playerNotoriety > 2)
        {
            int randomIndex = Random.Range(0, goodPassive.Count - 1);
            temp = neutralPassive[randomIndex];
            return temp;
        }
        else if (playerNotoriety < -2)
        {
            int randomIndex = Random.Range(0, badPassive.Count - 1);
            temp = badPassive[randomIndex];
            return temp;
        }
        else
        {
            int randomIndex = Random.Range(0, neutralPassive.Count - 1);
            temp = neutralPassive[randomIndex];
            return temp;
        }
    }
}