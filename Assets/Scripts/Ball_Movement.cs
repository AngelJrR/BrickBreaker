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
    public Vector2 direction;
    public GameMaster gameMaster;
    public Control paddle;
    Vector3 stuff;
    public bool poweredUp;
    public bool got = false;
    private Vector3 lastVelocity;
    private bool restart;
    public int value;
    //public AudioClip thump;
    //public AudioClip bounce;
    public AudioClip sizePowerup;
    public AudioClip speedPowerup;
    public AudioClip death;
    public AudioClip bounce;
    private AudioSource ballAudio;
    public ParticleSystem respawn;
    public ParticleSystem sizeParticle;
    public ParticleSystem speedParticle;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody2D>();
        ballSprite = GetComponent<SpriteRenderer>();
        gameMaster.GetComponent<GameMaster>();
        //StartCoroutine(DestroyPowerUp(10));
        StartCoroutine(SpawnPowerUp());
        paddle.GetComponent<Control>();
        paddle.paddleSprite.drawMode = SpriteDrawMode.Sliced;
        ballAudio = GetComponent<AudioSource>();
        //paddle.paddleCollider.autoTiling = true;
        restart = false;
    }

    // Update is called once per frame
    void Update()
    {
        //lastVelocity = ballRigidbody.velocity;
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
        //direction = ballRigidbody.velocity;
      //print(direction);
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
            gameMaster.playerLives--;
            respawn.Play();
            restart = true;
            ballAudio.PlayOneShot(death, .8f);
        }

        if (other.gameObject.tag == "Powerup")
        {
            poweredUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdown());
            if (!gameStart && value == 2)
                ballAudio.PlayOneShot(sizePowerup, .8f);
            else if(!gameStart && value == 1)
                ballAudio.PlayOneShot(speedPowerup, .8f);
            got = true;
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
            paddle.paddleSpeed -= 1;
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
                gameMaster.timed = true;
            }
        }
    }

    IEnumerator PowerupCountdown()
    {
        yield return new WaitForSeconds(10);
        print("why");
        if (!restart)
        {
            if (value == 1)
            {
                ballRigidbody.velocity /= 1.7f;
                print("asdjkasjdljwqld qw");
            }
            else
            {
                paddle.paddleSprite.size /= 2f;
                paddle.paddleCollider.size /= 2f;
                print("dsasadasdsadsa");
            }
        }
        else
            print("idk");
            restart = false;
        //ballSprite.color = Color.white;
        StartCoroutine(SpawnPowerUp());
    }

    IEnumerator SpawnPowerUp()
    {
        int wait = Random.Range(6, 15);
        yield return new WaitForSeconds(wait);
        int powerup = Random.Range(1, 3);
        //print(powerup);
        gameMaster.SpawnPowerUp(powerup);
            StartCoroutine(DestroyPowerUp(wait));
        value = powerup;
    }

    IEnumerator DestroyPowerUp(int wait)
    {
        
           // int wait = Random.Range(6, 15);
            yield return new WaitForSeconds(wait);
            Destroy(GameObject.FindGameObjectWithTag("Powerup"));
        if (!got)
            StartCoroutine(SpawnPowerUp());
        got = false;

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        ballSprite.color = new Color32(57,215,221,255);
        gameMaster.timed = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        ballAudio.PlayOneShot(bounce, .8f);
        if (!gameStart && spaced)
        {
            //speed increase

            ballRigidbody.velocity *= 1.4f;
            spaced = false;
            timed = true;
            paddle.paddleSpeed += 1;
        }

        if(poweredUp)
        {
            if (value == 1)
            {
                ballRigidbody.velocity *= 1.7f;
                //ballSprite.color = Color.blue;
                speedParticle.Play();
                //print("why");
            }
            else
            {
                sizeParticle.Play();
                paddle.paddleSprite.size *= 2f;
                paddle.paddleCollider.size *= 2f;
                //Bounds boundary = paddle.paddleCollider.bounds;
                //oundary.size = new Vector2(boundary.size.x * 2, boundary.size.y * 2);

                //print("idk");
            }

            poweredUp = false;
        }

        Vector3 surfaceNormal = other.contacts[0].normal;
     //   stuff = Vector3.Reflect(lastVelocity.normalized, surfaceNormal);
       // ballRigidbody.velocity = stuff * 5;
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

