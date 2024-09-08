using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood_box : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject wood_box;
    
    
    //The wood box has to be fired 3 times to be destroyed
    public int health = 3;


    //When the wood box is hit by the ammo, it loses health
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ammo")
        {
            health--;
            if (health == 0)
            {
                Destroy(wood_box);
            }
        }
    }
}
