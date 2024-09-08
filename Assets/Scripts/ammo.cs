using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ammo : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {

        Destroy(gameObject);
    }

    void Update(){
        // Destroy the ammo after 2 seconds
        Destroy(gameObject, 2);
    }
}
