using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour {


    [SerializeField] paddle paddle1;
    [SerializeField] private float xPush;
    [SerializeField] float speed;
    [SerializeField] AudioClip[] ballAudio;
    [SerializeField] AudioClip paddleAudio;
    [SerializeField] float randomNess = 2f;
    bool hasStarted = false;

    Rigidbody2D rigidBody;


    AudioSource myAudioSource;

    Vector2 paddleToBall;
	// Use this for initialization
	void Start () {
        paddleToBall = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (hasStarted == false) 
            LockBallOntPaddle();
        LaunchOnMouseClick();

    }

    private void LockBallOntPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBall;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0) && hasStarted == false)
        {
            hasStarted = true;
            rigidBody.velocity = new Vector2(xPush, speed);
            myAudioSource.PlayOneShot(paddleAudio);
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 random = new Vector2(Random.Range(-randomNess, randomNess),Random.Range(-randomNess, randomNess));
        if (hasStarted == true)
        {
            
            rigidBody.velocity += random;
            AudioClip clip = ballAudio[Random.Range(0, ballAudio.Length)];
            myAudioSource.PlayOneShot(clip);
        }

    }
}
