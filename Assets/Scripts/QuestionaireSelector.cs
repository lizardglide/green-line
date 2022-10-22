using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QuestionaireSelector : MonoBehaviour
{
    public int QuestionIndex;
    public Questionaire [] Questions;
    [SerializeField]
    private TextAsset filePath;

    void Start()
    {
        //test json to
        /*
        QuestionaireCollection qc2 = new QuestionaireCollection();
        qc2.Questions = new Questionaire[1];
        Questionaire q = new Questionaire();
        q.Question = "test_question?";
        q.Answers = new string[]{
            "a1",
            "a2",
            "a3"
        };
        q.CorrectAnswerIndex = 2;
        qc2.Questions[0] = q;
        string qc2Res;
        Debug.Log(qc2Res = JsonUtility.ToJson(qc2));
        */

        //json from
        string strData = filePath.text;
        QuestionaireCollection qc = JsonUtility.FromJson<QuestionaireCollection>(strData);
        Questions = qc.Questions;
    }
}

[Serializable]
public class QuestionaireCollection
{
    public QuestionaireCollection () {}
    public Questionaire[] Questions;
}