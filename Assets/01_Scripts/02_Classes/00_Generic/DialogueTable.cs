using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTable : MonoBehaviour{

    public string passiveAnswerKey,
                  passiveQuestionKey,
                  activeAnswerKey,
                  activeQuestionKey;

    public List<TextAsset> dreailyDreamingTextFiles;

    public static Dictionary<string,string> passiveAnswerList,
                                            passiveQuestionList,
                                            activeAnswerList,
                                            activeQuestionList;
    private void Awake()
    {
        LoadTextAssets();
    }
    private void LoadTextAssets() {
        //Loop through each file in the List
        foreach(TextAsset textFile in dreailyDreamingTextFiles) 
        {
            string[] eachLine;                  //array for storage of each full line of text from the file
            string tempString = textFile.text;  //string variable to hold the data from the file
                        
            eachLine = tempString.Split('\n');  //parse data into individual lines
            foreach (string section in eachLine)    //parse each line into two sections; index 0: dictionary key. index 1: string for storage
            {
                //formatting for the file should be "listkey_dialogue\n" ex. "passive answer_I am the real Slim Shady!"
                string[] splitLine = section.Split('_');    //split the line at the underscore
                string keyWord,dialogue;
                //switch (textFile.name)
                //{
                //    case "passiveAnswer":
                //        keyWord = splitLine[0];
                //        dialogue = splitLine[1];
                //        passiveAnswerList.Add(keyWord,dialogue);
                //        break;
                //    case "passiveQuestion":
                //        keyWord = splitLine[0];
                //        dialogue = splitLine[1];
                //        passiveQuestionList.Add(keyWord, dialogue);
                //        break;
                //    case "activeAnswer":
                //        keyWord = splitLine[0];
                //        dialogue = splitLine[1];
                //        activeAnswerList.Add(keyWord, dialogue);
                //        break;
                //    case "activeQuestion":
                //        keyWord = splitLine[0];
                //        dialogue = splitLine[1];
                //        activeQuestionList.Add(keyWord, dialogue);
                //        break;
                //    default:
                //        break;
                //}
            }
            
        }



    }
}
