using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    using UnityEngine.SceneManagement;
public class day_game : MonoBehaviour
{
    // Start is called before the first frame update

    
    public void OnclickDay()
    {
        SceneManager.LoadScene("Game_Day");
    }

    public void OnclickNight()
    {
        SceneManager.LoadScene("Game_Night");
    }

}
