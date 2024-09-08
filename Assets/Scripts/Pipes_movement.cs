using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    private float speed = 2.0f;  // Vitesse du déplacement

    void Update()
    {
        if (Point_calculator.score <10){
            speed = 2.0f;
        }
        else if (Point_calculator.score <20 && Point_calculator.score >=10){
            speed = 2.5f;
        }
        else if (Point_calculator.score <30 && Point_calculator.score >=20){
            speed = 3.0f;
        }
        else {
            speed = 3.5f;
        }
        // Déplacer le pipe vers la gauche
        transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);

        // Détruire le pipe s'il sort de l'écran (par exemple quand x < -10)
        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }
}
