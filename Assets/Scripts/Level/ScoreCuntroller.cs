using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreCuntroller : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    
    private int score = 0;

    private void Awake(){
        scoreText = GetComponent<TextMeshProUGUI>();
    }
    private void Start(){
        RefreshUI();
    }

    public void IncreaseScore(int increment){
        score += increment;
        RefreshUI();

    }

    private void RefreshUI()
    {
        scoreText.text = "Score:" + score;
    }
}
