using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private float score = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        this.score +=  Time.deltaTime;
    }

    public float Score {
        get {
            return this.score;
        }
        
        set {
            this.score = value;
        }
    }
}
