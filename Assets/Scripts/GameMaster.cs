using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public float maxLevelBricks;
    public float playerLives = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLives <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }

        if (maxLevelBricks >= 25)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
