using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ScoreManager))]
public class GameManager : MonoBehaviour
{
    [SerializeField]
    AudioClip sndSuccess;
    [SerializeField]
    AudioClip sndFail;
    AudioSource audio;

    [SerializeField]
    AudioSource music;

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

    void Start()
    {
        this.scoreManager = this.gameObject.GetComponent<ScoreManager>();
    }

    void AnswerSelect(int index){
        if(!this.buttonsActive) return;
        if(!this.HasQuestionPrompt) return;
        if(index == CurrQuestionSelector.CorrectAnswerIndex) {
            //correct
            scoreManager.Score -= 1f / 6f;
            Camera.main.gameObject.GetComponent<AudioSource>().PlayOneShot(this.sndSuccess);
            this.angel.Agitator = 15;
            StartCoroutine(SucceedAnswer());
        } else {
            //false
            scoreManager.Score += 2f / 6f;
            Camera.main.gameObject.GetComponent<AudioSource>().PlayOneShot(this.sndFail);
            this.devil.Agitator = 15;
            StartCoroutine(FailedAnswer());
        }

        if(scoreManager.Score >= 1f){
            //load gameover
            SceneManager.LoadScene(2);
        }

        music.pitch = 0.5f + ((scoreManager.Score * -1 + 1)/2);
    }

    IEnumerator SucceedAnswer()
    {
        this.buttonsActive = false;
        yield return new WaitForSeconds(3);
        //TODO: load next question
        this.IncQuestionIndex();
        this.buttonsActive = true;
    }

    IEnumerator FailedAnswer()
    {
        this.buttonsActive = false;
        this.isHintVisible = true;
        yield return new WaitForSeconds(6);
        this.isHintVisible = false;
        yield return new WaitForSeconds(2);
        this.IncQuestionIndex();
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
    public void Test_SetQuestionIndex()
    {
        SetQuestionIndex(0);
    }

    void IncQuestionIndex()
    {
        this.currentQuestion+=1;
        if(this.currentQuestion >= this.questionSelector.Questions.Length)
        {
            //TODO: Game end no more questions
            Debug.Log("Cleared Questions");

            if(this.scoreManager.Score > 0){
                //LOSS
                SceneManager.LoadScene(2);
            }
            else {
                //Victory
                SceneManager.LoadScene(3);
            }

            return;
        }
        this.QuestionChange_Event();
    }

    public void SetQuestionIndex(int index)
    {
        this.currentQuestion = index;
        this.QuestionChange_Event();
    }
}
