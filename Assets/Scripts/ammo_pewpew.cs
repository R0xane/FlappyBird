using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo_pewpew : MonoBehaviour
{
    public Rigidbody2D ammo;  // The prefab for the projectile (2D version)
    public Transform spawn;  // The spawn point for the projectile
    private float speed = 50f;  // Speed of the projectile

    void Start()
    {
        // Optional: Initialization code can go here
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Check for mouse click
        {
            // Instantiate the ammo at the spawn point, rotated -90 degrees
            Rigidbody2D newAmmo = Instantiate(ammo, spawn.transform.position, Quaternion.Euler(0, 0, -90));


            // Set the velocity of the projectile to move it in the right direction
            newAmmo.velocity = spawn.right * speed;

            // Destroy object after 2 seconds
            Destroy(newAmmo.gameObject, 2);
        }   
    }
}
