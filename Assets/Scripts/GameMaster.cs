using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameMaster : MonoBehaviour
{
    public float maxLevelBricks;
    public float playerLives = 3;
    public float points;
    public Text LivesTx;
    public Text ScoreTx;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        LivesTx.text = "Lives: " + playerLives;
        ScoreTx.text = "Score: " + points;
    }

    // Update is called once per frame
    void Update()
    {
       

        if (playerLives <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }

        if (maxLevelBricks >= 23)
        {
            SceneManager.LoadScene("WinScene");
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            playerLives = 5;
                SceneManager.LoadScene("Level 1");
        }
        LivesTx.text = "Lives: " + playerLives;
        ScoreTx.text = "Score: " + points;
    }
}
