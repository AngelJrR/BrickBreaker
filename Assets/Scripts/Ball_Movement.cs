using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball_Movement : MonoBehaviour
{

    public bool gameStart = true;
    public Rigidbody2D ballRigidbody;
    public Vector2[] startDirections;
    public int randomNumber;
    public float ballForce;
    public Vector3 startPosition;


    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameStart)
        {
            //speed boost
            ballForce = 20;

        }

        if (Input.GetKeyDown(KeyCode.Space) && gameStart)
        {
            //launch ball
            randomNumber = Random.Range(0, startDirections.Length);
            ballRigidbody.AddForce(startDirections[randomNumber] * ballForce, ForceMode2D.Impulse);
            gameStart = false;

        }

 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DefeatZone")
        {
            ballRigidbody.velocity = Vector3.zero;
            transform.position = startPosition;
            gameStart = true;
        }
    }
}

