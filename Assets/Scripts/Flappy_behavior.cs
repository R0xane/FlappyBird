using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBird : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody_mid;
    private float _speed = 10f;
    [SerializeField]
    public GameObject pipe_Spawn;
    public End_game endGame;

    public static bool isDead { get; set; }

    // Audio settings
    public AudioClip Sound_crash;  
    public AudioClip flying;  
    private AudioSource audioSource; 
    private AudioSource fly_sound;
    public GameObject explosion;

    public AudioClip point;
    private AudioSource point_sound;
    public GameObject advice;
    

    void Start()
    {
        Time.timeScale = 0;
        _rigidbody_mid = GetComponent<Rigidbody2D>();

        // Get or add an AudioSource component
        audioSource = GetComponent<AudioSource>();
        audioSource = gameObject.AddComponent<AudioSource>();

        // Assign the AudioClip in the Inspector, or via script like below
        audioSource.clip = Sound_crash;

        fly_sound = GetComponent<AudioSource>();
        fly_sound = gameObject.AddComponent<AudioSource>();
        fly_sound.clip = flying;

        point_sound = GetComponent<AudioSource>();
        point_sound = gameObject.AddComponent<AudioSource>();
        point_sound.clip = point;

        advice.SetActive(true);

        isDead = false;

    }




    void Update()
    {
        // Handle bird movement
        if (Input.GetKeyDown(KeyCode.Space) && isDead == false)
        {
            advice.SetActive(false);
            Time.timeScale = 1;
            _rigidbody_mid.velocity = Vector2.up * _speed;
            _rigidbody_mid.AddForce(new Vector2(0f, 5f));
            fly_sound.Play();
        }

        // Verify bird position in relation to pipes
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("set_pipes");
        foreach (GameObject pipe in pipes)
        {
            Bird_pipes(pipe);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 position = _rigidbody_mid.transform.position;
        Instantiate(explosion, position, Quaternion.identity);
        Time.timeScale = 0;
        Debug.Log("Collision detected");

        // Play the sound when a collision happens
        audioSource.Play();

 

        // Instantiate the explosion at the bird's position
        isDead = true;
        endGame.GameOver();


    }

    private void Bird_pipes(GameObject pipe)
    {
        float tolerance = 0.2f;

        pipe pipe_script = pipe.GetComponent<pipe>();

        if (pipe_script.isScored == false && Mathf.Abs(pipe.transform.position.x - _rigidbody_mid.transform.position.x) < tolerance)
        {
            Debug.Log("Score + 1");
            point_sound.Play();
            Point_calculator.score += 1;
            pipe_script.isScored = true;
        }
    }
}
