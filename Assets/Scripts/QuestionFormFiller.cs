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
	TMP_Text button1, button2, button3, question, hint;
	[SerializeField]
	Image pillar;
	[SerializeField]
	RectTransform hintWnd;
	[SerializeField]
	float hintWndSpeed = 150;

	void Start()
	{
		this.gameManager.QuestionChange_Event = EventTrigger;
		this.defaultY = this.hintWnd.transform.position.y;
	}

	float hintY = 0;
	float defaultY = 0;

	void Update()
	{
		if(this.gameManager.IsHintVisible)
		{
			if(hintY == 800) return;
			hintY += Time.deltaTime * hintWndSpeed;
			if(hintY > 800) hintY = 800;
			this.hintWnd.transform.position = new Vector2(
				this.hintWnd.transform.position.x,
				defaultY - hintY
			);
		}
		else
		{
			if(hintY == 0) return;
			hintY -= Time.deltaTime * hintWndSpeed;
			if(hintY < 0) hintY = 0;
			this.hintWnd.transform.position = new Vector2(
				this.hintWnd.transform.position.x,
				defaultY - hintY
			);
		}
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
			hint.text = string.Empty;
			pillar.sprite = null;
			if(pillar.sprite == null) pillar.enabled = false;
		
			return;
		}

		button1.text = gameManager.CurrQuestionSelector.Answers[0];
		button2.text = gameManager.CurrQuestionSelector.Answers[1];
		button3.text = gameManager.CurrQuestionSelector.Answers[2];
		question.text = gameManager.CurrQuestionSelector.Question;
		hint.text = gameManager.CurrQuestionSelector.Hint;

		string resourceName = $"Pillars/{gameManager.CurrQuestionSelector.PillarName}";

		Sprite sp = Resources.Load<Sprite>(resourceName);
		pillar.sprite = sp;

		if(pillar.sprite == null) pillar.enabled = false;
    }
	
}



