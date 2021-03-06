using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCollision : MonoBehaviour
{
    public int numberOfHits = 0;
    public int maxHits;
    public SpriteRenderer brickSprite;
    public GameMaster gameMaster;
    public AudioClip thump;
   // public AudioClip bounce;
    private AudioSource paddleAudio;
    public ParticleSystem dustParticles;
    public ParticleSystem destroyParticles;
    public DestroySound destroyed;

    // Start is called before the first frame update
    void Start()
    {
        brickSprite = GetComponent<SpriteRenderer>();
        gameMaster.GetComponent<GameMaster>();
        paddleAudio = GetComponent<AudioSource>();
        destroyed.GetComponent<DestroySound>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {

        // if (gameObject != null)
        dustParticles.Play();

        if (maxHits == 100)
        {
            brickSprite.color = Color.green;
            //paddleAudio.PlayOneShot(bounce, .4f);
            if (!gameMaster.timed)
                numberOfHits--;
            else
                numberOfHits += 1000;
        }

        numberOfHits++;
        gameMaster.points++;

        if (maxHits == 2)
            brickSprite.color = Color.red;

        if (maxHits == 5)
            brickSprite.color = Color.blue;

        if (numberOfHits < 0)
        {
            brickSprite.color = Color.gray;
            paddleAudio.PlayOneShot(thump, .8f);
        }

        if (numberOfHits >= maxHits)
        {
            //Instantiate(destroyParticles, this.transform.position, this.transform.rotation);
            destroyed.Sounds();
            destroyParticles.transform.parent = null;
            destroyParticles.Play();
            gameMaster.LevelBricks++;
            Destroy(gameObject);

        }
 

    }
}
