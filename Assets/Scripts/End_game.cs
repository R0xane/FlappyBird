using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class End_game : MonoBehaviour
{
    // Start is called before the first frame update
    public Text BestScore;
    public GameObject gameover;




    public void GameOver()
    {
        gameover.SetActive(true);
        BestScore.text = "Best Score: " + PlayerPrefs.GetInt("BestScore", Point_calculator.score);


    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);

    }

    public void Quit()
    {
        Application.LoadLevel("Menu");
    }


}
