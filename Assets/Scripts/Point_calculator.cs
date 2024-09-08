using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point_calculator : MonoBehaviour
{
    public Text scoreText;
    public static int score;
    
    void Start()
    {
        score = 0;
        
    }

    
    void Update()
    {
        scoreText.text = "Score: " + Mathf.Round(score);
    }

    public void BestScore()
    {
        if (score > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
    }
}
