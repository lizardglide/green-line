using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class QuestionFormFiller : MonoBehaviour 
{
	[SerializeField]
	GameManager1 gameManager;
	[SerializeField]
	TMP_Text button1, button2, button3, question;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		button1.text="button1";
		
		/**button1 = gameManager.QuestionSelector.Answers[1];
					
		button2 = gameManager.QuestionSelector.Answers[2];
		
		button3 = gameManager.QuestionSelector.Answers[3];
			
		question = gameManager.QuestionSelector.ques; **/
        
    }
	
	void onClick(){
		Console.Write("test");
		
		//gameManager.AnswerSelect(1);
		
	}
}

class Questionere {

	string question;
	string[] answers = new string[8];
	int correctAnswerIndex;
	
}

class QuestionSelector {
	int questionIndex;
	//Questionere[] ques = new Questionere[10];	

}




