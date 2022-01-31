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
    public SpriteRenderer ballSprite;
    private bool timed = false;
    private float distance;
    public bool spaced = false;
    public bool collided = false;
    private float x;
    private float y;
    public Vector2 direction;
    public GameMaster gameMaster;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        ballSprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && gameStart)
        {
            //launch ball
            randomNumber = Random.Range(0, startDirections.Length);
            ballRigidbody.AddForce(startDirections[randomNumber] * ballForce, ForceMode2D.Impulse);
            //print("Nah" + startDirections[randomNumber] * ballForce);
            gameStart = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ballRigidbody.velocity = Vector3.zero;
            transform.position = startPosition;
            gameStart = true;
        }


        /*
        if (ballRigidbody.velocity.x < 0)
            x = -1;
        else
            x = 1;
        if (ballRigidbody.velocity.y < 0)
            x = -1;
        else
            x = 1;
        */
        direction = ballRigidbody.velocity;
      print(direction);
        //
        //spaced = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "DefeatZone")
        {
            
            ballRigidbody.velocity = Vector3.zero;
            transform.position = startPosition;
            gameStart = true;
            gameMaster.playerLives = gameMaster.playerLives--;
        }

        /*
        if (collided && spaced)
            timed = true;
        else
            timed = false;
        //collided = false
        */
        //ballSprite.color = Color.blue;

        if (timed)
        {
            ballRigidbody.velocity /= 1.3f;
            timed = false;
            /*
            if (other.gameObject.tag == "Respawn")
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyUp(KeyCode.Space))
                {
                    ballSprite.color = Color.green;
                    spaced = true;
                }
            }
            */
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Respawn")
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyUp(KeyCode.Space))
            {
                ballSprite.color = Color.green;
                spaced = true;
            }
        }
    }


    


    private void OnTriggerExit2D(Collider2D collision)
    {
        ballSprite.color = Color.white;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (!gameStart && spaced)
        {
            //speed increase

            ballRigidbody.velocity *= 1.5f;
            spaced = false;
            timed = true;
        }

            //ballForce = 10;
            //ballRigidbody.velocity = Vector3.one;
            //ballRigidbody.AddForce(direction * ballForce, ForceMode2D.Impulse);
            //print("Hi" + direction * ballForce);

            /* if (!timed && !gameStart)
            {
                ballSprite.color = Color.red;

            }
            */

            /*
            if (timed && !gameStart)
            {
                //speed boost
                ballSprite.color = Color.blue;
                ballForce = 50;
                timed = false;
            }
            */



    }
}

