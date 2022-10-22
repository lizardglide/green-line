using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System;

public class QuestionFormFiller : MonoBehaviour 
{
	[SerializeField]
	GameManager gameManager;
	[SerializeField]
	TMP_Text button1, button2, button3, question;
	[SerializeField]
	Image pillar;

	void Start()
	{
		this.gameManager.QuestionChange_Event = EventTrigger;
	}

    void EventTrigger()
    {
		pillar.enabled = true;
		if(!gameManager.HasQuestionPrompt)
		{
			button1.text = string.Empty;
			button2.text = string.Empty;
			button3.text = string.Empty;
			question.text = string.Empty;
			pillar.sprite = null;
			if(pillar.sprite == null) pillar.enabled = false;
		
			return;
		}

		button1.text = gameManager.CurrQuestionSelector.Answers[0];
		button2.text = gameManager.CurrQuestionSelector.Answers[1];
		button3.text = gameManager.CurrQuestionSelector.Answers[2];
		question.text = gameManager.CurrQuestionSelector.Question;

		string resourceName = $"Pillars/{gameManager.CurrQuestionSelector.PillarName}";

		Sprite sp = Resources.Load<Sprite>(resourceName);
		pillar.sprite = sp;

		if(pillar.sprite == null) pillar.enabled = false;
    }
	
	void onClick(){
		Console.Write("test");
		
		//gameManager.AnswerSelect(1);
		
	}
}



