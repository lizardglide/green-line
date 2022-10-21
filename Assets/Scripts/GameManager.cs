using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    ScoreManager scoreManager;
    QuestionaireSelector questions;
    
    int currentQuestion;
    Questionaire curQuestionSelector {
        get {
            return questions.Arr[currentQuestion];
        }
    }

    void AnswerSelect(int index){
        scoreManager.Score += 1;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
