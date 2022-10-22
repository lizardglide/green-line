using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    ScoreManager scoreManager;
    [SerializeField]
    QuestionaireSelector questionSelector;
    
    [SerializeField]
    int currentQuestion = -1;

    public bool HasQuestionPrompt {
        get {
            return (currentQuestion != -1);
        }
    }

    public Questionaire CurrQuestionSelector {
        get {
            if(currentQuestion == -1) return null;
            return questionSelector.Questions[currentQuestion];
        }
    }

    public delegate void TriggerQuestionChange();
    public TriggerQuestionChange QuestionChange_Event;

    
    void AnswerSelect(int index){
        if(!this.HasQuestionPrompt) return;
        //scoreManager.Score += 1;
    }

    public void AnswerSelect_1()
    {
        AnswerSelect(0);
    }
    public void AnswerSelect_2()
    {
        AnswerSelect(1);
    }
    public void AnswerSelect_3()
    {
        AnswerSelect(2);
    }

    [ContextMenu("Test Question")]
    void Test_SetQuestionIndex()
    {
        SetQuestionIndex(0);
    }

    void SetQuestionIndex(int index)
    {
        this.currentQuestion = index;
        this.QuestionChange_Event();
    }
}
