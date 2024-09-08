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

    // Audio settings
    public AudioClip Sound_crash;  // This should be your collision sound
    public AudioClip flying;  // This should be your jump sound
    private AudioSource audioSource; // Audio source to play sound
    private AudioSource fly_sound;
    public GameObject explosion;

    void Start()
    {
        Time.timeScale = 1;
        _rigidbody_mid = GetComponent<Rigidbody2D>();

        // Get or add an AudioSource component
        audioSource = GetComponent<AudioSource>();
        audioSource = gameObject.AddComponent<AudioSource>();

        // Assign the AudioClip in the Inspector, or via script like below
        audioSource.clip = Sound_crash;

        fly_sound = GetComponent<AudioSource>();
        fly_sound = gameObject.AddComponent<AudioSource>();
        fly_sound.clip = flying;

    }

    void Update()
    {
        // Handle bird movement
        if (Input.GetKeyDown(KeyCode.Space))
        {
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

    // Detect collision and handle game over logic
        //_rigidbody_mid.transform.position = new Vector3(0, 0, -2.4f);
 

        // Instantiate the explosion at the bird's position


        endGame.GameOver();


    }

    private void Bird_pipes(GameObject pipe)
    {
        float tolerance = 0.2f;

        pipe pipe_script = pipe.GetComponent<pipe>();

        if (pipe_script.isScored == false && Mathf.Abs(pipe.transform.position.x - _rigidbody_mid.transform.position.x) < tolerance)
        {
            Debug.Log("Score + 1");
            Point_calculator.score += 1;
            pipe_script.isScored = true;
        }
    }
}
