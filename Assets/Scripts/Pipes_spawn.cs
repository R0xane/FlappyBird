using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class Pipes_spawn : MonoBehaviour
{
    public GameObject pipePrefab;  
    public GameObject Pipe_spawn;  
    public GameObject wood_box;

    public GameObject ceiling;
    public GameObject floor;
    private float minSpawnRate; 
    private float maxSpawnRate; 
    
    
    void Start()
    {
        // Démarrer la coroutine pour générer des pipes à intervalles aléatoires
        StartCoroutine(SpawnPipes());
    }

    IEnumerator SpawnPipes()
    {
        while (true)
        {
            // Créer un délai aléatoire entre minSpawnRate et maxSpawnRate
            if (Point_calculator.score <10){
                minSpawnRate = 1.5f;
                maxSpawnRate = 4.0f;
            }
           else if (Point_calculator.score <20 && Point_calculator.score >=10){
                minSpawnRate = 1.5f;
                maxSpawnRate = 2.5f;
            }
            else if (Point_calculator.score <30 && Point_calculator.score >=20){
                minSpawnRate = 1.5f;
                maxSpawnRate = 2f;
            }
            else {
                minSpawnRate = 1f;
                maxSpawnRate = 1.5f;
            }

            float waitTime = UnityEngine.Random.Range(minSpawnRate, maxSpawnRate);

            // Attendre ce délai avant de générer un nouveau pipe
            yield return new WaitForSeconds(waitTime);

            // Appeler la méthode CreatePipe() pour créer un nouveau pipe
            CreatePipe();
        }

    }

    public void CreatePipe()
{
    // Créer l'objet parent "pipes" à la position de Pipe_spawn
    GameObject pipes = new GameObject("pipes");
    pipes.transform.position = Pipe_spawn.transform.position; // Mettre le parent pipes à la même position que Pipe_spawn
    pipes.tag = "set_pipes";
    pipes.AddComponent<pipe>();
    // Générer une hauteur aléatoire 
    float randomHeight_down = 0f;
    float randomHeight_up = 0f;
    randomHeight_down = UnityEngine.Random.Range(4f, 9.3f);

    randomHeight_up = UnityEngine.Random.Range(-5.4f, -0.25f);
    float diff = randomHeight_down - randomHeight_up;

    int random_wood = UnityEngine.Random.Range(0, 2);
    if (Point_calculator.score <= 10){
        if (diff < 14){
            //Choisir aléatoirement entre les deux hauteurs
            int random_choose = UnityEngine.Random.Range(0, 2);
            if (random_choose == 0){
                randomHeight_down = (float)(randomHeight_down + (14 - diff));
            }
            else{
                randomHeight_up = (float)(randomHeight_up - (14 - diff));
            }
        }
    }
    else if (Point_calculator.score > 10 && Point_calculator.score < 20){
        if (diff < 12.5){
            //Choisir aléatoirement entre les deux hauteurs
            int random_choose = UnityEngine.Random.Range(0, 2);
            if (random_choose == 0){
                randomHeight_down = (float)(randomHeight_down + (14 - diff));
            }
            else{
                randomHeight_up = (float)(randomHeight_up - (14 - diff));
            }
        }
    }
    else if (Point_calculator.score >= 20 && Point_calculator.score < 30){
        if (diff < 11){
        //Choisir aléatoirement entre les deux hauteurs
        int random_choose = UnityEngine.Random.Range(0, 2);
        if (random_choose == 0){
            randomHeight_down = (float)(randomHeight_down + (11 - diff));
        }
        else{
            randomHeight_up = (float)(randomHeight_up - (11 - diff));
        }
        }
    }
    else if (Point_calculator.score >= 30){
        if (diff < 9.5){
        //Choisir aléatoirement entre les deux hauteurs
        int random_choose = UnityEngine.Random.Range(0, 2);
        if (random_choose == 0){
            randomHeight_down = (float)(randomHeight_down + (9.5 - diff));
        }
        else{
            randomHeight_up = (float)(randomHeight_up - (9.5 - diff));
        }
        }
    }




   

   
    GameObject pipe_up = Instantiate(pipePrefab, pipes.transform); 
    pipe_up.transform.localPosition = new Vector3(0, randomHeight_up, -1f); 

    
    
    GameObject pipe_down = Instantiate(pipePrefab, pipes.transform); 
    pipe_down.transform.localPosition = new Vector3(0, randomHeight_down, -1f); 
    pipe_down.transform.Rotate(0, 0, 180);  


    pipe_down.tag = "Obstacle"; 
    pipe_up.tag = "Obstacle"; 
    pipe_down.AddComponent<BoxCollider2D>(); 
    pipe_up.AddComponent<BoxCollider2D>(); 


    float middleY = (randomHeight_up + randomHeight_down) / 2f;


    //We need to verify if the box is not in the ceiling or the floor
    if (ceiling.transform.position.y - middleY < 2.5f){
        middleY = (middleY + ceiling.transform.position.y - 1f )/2f;
    }
    if (floor.transform.position.y - middleY > -2.5f){
        middleY = (middleY - floor.transform.position.y + 1f )/2f;
    }

    //Create wood object to be an obstacle
    if (random_wood == 0) {
        GameObject wood = Instantiate(wood_box, pipes.transform); 
        wood.transform.localPosition = new Vector3(0, middleY, -1f); //Position the wood in the middle of the two pipes
        wood.AddComponent<BoxCollider2D>(); 
    }

    // The pipes will be children of the pipes object
    pipes.transform.parent = Pipe_spawn.transform;

    // Add the PipeMovement script to the pipes object
    PipeMovement pipeMovement = pipes.AddComponent<PipeMovement>();
}
}

