using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTable {
    public TextAsset passiveAnswerFile,
                     passiveQuestionFile,
                     activeAnswerFile,
                     activeQuestionFile;
    public static List<string> passiveAnswerList,
                               passiveQuestionList,
                               activeAnswerList,
                               activeQuestionList;
}
