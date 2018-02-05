using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTable : MonoBehaviour{

    //list of all dialogue files for this class
    public TextAsset passiveTextFile;//,activeTextFile;

    [HideInInspector] public static List<string> passiveConversations = new List<string>();//,
                                                 //activeConversations;
    
    private void Awake()
    {
        LoadTextAssets();
        Debug.Log("On Awake:" + passiveTextFile.text);
    }
    private void LoadTextAssets() {
        string[] eachPassiveLine;
        string passiveText = passiveTextFile.text;
        Debug.Log("Before the split: " + passiveText);

        eachPassiveLine = passiveText.Split('\n');

        Debug.Log("At the Split(): " + eachPassiveLine.ToString());

        foreach(string line in eachPassiveLine)
        {
            passiveConversations.Add(line);
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
        //}*/
    }
    public static string PickRandomPassive() {
        int random = Random.Range(0, passiveConversations.Count);
        string temp = passiveConversations[random];
        return temp;
    }
}