using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_play_quit : MonoBehaviour
{
    public void OnclickPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnclickQuit()
    {
        Application.Quit();
    }
}
