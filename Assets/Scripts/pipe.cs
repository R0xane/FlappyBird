using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isScored = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0;
    }
}
