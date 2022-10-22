using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimLevelTrigger : MonoBehaviour
{
    [SerializeField]
    GameManager gameManager;

    public void StartQuestionaire()
    {
        this.gameManager.SetQuestionIndex(0);
    }
}
