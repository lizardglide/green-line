using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Questionaire
{
    public Questionaire() {}

    public string Question;
    public string [] Answers;
    public int CorrectAnswerIndex;
    public string PillarName;
    public string Hint;
}
