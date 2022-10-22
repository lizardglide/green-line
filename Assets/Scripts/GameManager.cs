using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    AudioClip sndSuccess;
    [SerializeField]
    AudioClip sndFail;
    AudioSource audio;

    ScoreManager scoreManager;
    [SerializeField]
    QuestionaireSelector questionSelector;
    
    [SerializeField]
    int currentQuestion = -1;

    [SerializeField]
    SpriteIdleAnim devil;
    [SerializeField]
    SpriteIdleAnim angel;

    private bool buttonsActive = true;
    private bool isHintVisible = false;
    public bool IsHintVisible { get { return this.isHintVisible; }}

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
        if(!this.buttonsActive) return;
        if(!this.HasQuestionPrompt) return;
        if(index == CurrQuestionSelector.CorrectAnswerIndex) {
            //correct
            Camera.main.gameObject.GetComponent<AudioSource>().PlayOneShot(this.sndSuccess);
            this.angel.Agitator = 15;
            StartCoroutine(SucceedAnswer());
        } else {
            //false
            Camera.main.gameObject.GetComponent<AudioSource>().PlayOneShot(this.sndFail);
            this.devil.Agitator = 15;
            StartCoroutine(FailedAnswer());
        }
    }

    IEnumerator SucceedAnswer()
    {
        this.buttonsActive = false;
        yield return new WaitForSeconds(3);
        //TODO: load next question
        this.buttonsActive = true;
    }

    IEnumerator FailedAnswer()
    {
        this.buttonsActive = false;
        this.isHintVisible = true;
        yield return new WaitForSeconds(10);
        this.isHintVisible = false;
        yield return new WaitForSeconds(5);
        //TODO: load next question
        this.buttonsActive = true;
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

    void IncQuestionIndex()
    {
        this.currentQuestion++;
        if(this.currentQuestion >= this.questionSelector.Questions.Length)
        {
            //TODO: Game end no more questions
        }
    }

    void SetQuestionIndex(int index)
    {
        this.currentQuestion = index;
        this.QuestionChange_Event();
    }
}
