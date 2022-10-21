using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SliderController : MonoBehaviour
{
    public Slider slider;
    public ScoreManager scoreManager;
    float f;

    void Start()
    {
        slider = this.gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        f = (Mathf.Sin(scoreManager.Score)/2) +0.5f;
        slider.value = f;
    }
}
