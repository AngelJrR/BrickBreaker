using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameMaster : MonoBehaviour
{
    public float LevelBricks;
    public float maxLevelBricks;
    public float playerLives = 3;
    public float points;
    public Text LivesTx;
    public Text ScoreTx;
    public bool timed;
    public GameObject powerUpSpeedPrefab;
    public GameObject powerUpSizePrefab;
    public bool spawn;
    public int level;

    private void Awake()
    {
       // DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        LivesTx.text = "Lives: " + playerLives;
        ScoreTx.text = "Score: " + points;
        //SpawnPowerUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLives <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }

        if (LevelBricks >= maxLevelBricks)
        {
            SceneManager.LoadScene("WinScene");
            playerLives = 3;
        }

        
        if (Input.GetKeyDown(KeyCode.Y))
        {
            playerLives = 3;
        }
        
        LivesTx.text = "Lives: " + playerLives;
        ScoreTx.text = "Score: " + points;

        //if (spawn)
            //SpawnPowerUp();
           // spawn = false;
    }

    private Vector2 GenerateSpawnPos()
    {
        float spawnY;
        float spawnX;
        if (level == 3)
        {
            spawnY = Random.Range(-3, 3);
            spawnX = Random.Range(-8, 8);
        }
        else if (level == 4)
        {
            spawnY = Random.Range(3, 1);
            spawnX = Random.Range(-8, 8);
        }
        else
                {
            spawnY = Random.Range(-3, -1);
            spawnX = Random.Range(-8, 8);
        }
        Vector2 position = new Vector2(spawnX, spawnY);
     return position;
    }
    
    public void SpawnPowerUp(int powerup)
    {
        if(powerup == 1)
        Instantiate(powerUpSpeedPrefab, GenerateSpawnPos(), powerUpSpeedPrefab.transform.rotation);
        else
            Instantiate(powerUpSizePrefab, GenerateSpawnPos(), powerUpSizePrefab.transform.rotation);
    }

}
