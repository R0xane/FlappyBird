using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo_pewpew : MonoBehaviour
{
    public Rigidbody2D ammo;  
    public GameObject spawn;  
    private float speed = 50f;  
    public AudioClip sound; 
    private AudioSource audioSource; 

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = sound;

    }

    void Update()
    {
        // Vérifie si une des touches directionnelles est pressée
        if (ControlBird.isDead == false)
        {
        
            if (Input.GetKeyDown(KeyCode.UpArrow)) 
            {

                Fire(Vector2.up, 0);  
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow)) 
            {
                Fire(Vector2.down, 180);  
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow)) 
            {
                Fire(Vector2.right, -90); 
            }
        }
    }

    // Méthode pour tirer un projectile dans une direction donnée et avec une rotation spécifiée
    void Fire(Vector2 direction, float rotationZ)
    {
        audioSource.Play();  
        Rigidbody2D newAmmo = Instantiate(ammo, spawn.transform.position, Quaternion.Euler(0, 0, rotationZ));
        newAmmo.tag = "Ammo";  // Assigne le tag "Ammo" au projectile

        newAmmo.velocity = direction * speed;

    }


}
