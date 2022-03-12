using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
   public int level;
   //public AudioClip Level1;
 //  private AudioSource cameraAudio;

    // Start is called before the first frame update
    void Start()
    {
       // cameraAudio = GetComponent<AudioSource>();
        //cameraAudio.PlayOneShot(Level1, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            //level++;
            //print(level);
            nextLevel();
           // print(level);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            
            level = 1;
            SceneManager.LoadScene("Main Menu");
            
            
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Learn()
    {
        SceneManager.LoadScene("How To Play");
    }
    public void Story()
    {
        SceneManager.LoadScene("Story");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    public void restart()
    {
        if (level == 1)
        {
            //level = 2;
            SceneManager.LoadScene("Level 1");
            // level = 2;
        }

        else if (level == 2)
        {
            // level = 3;
            SceneManager.LoadScene("Level 2");

        }

        else if (level == 3)
        {
            // level = 4;
            SceneManager.LoadScene("Level 3");

        }

        else if (level == 4)
        {
            SceneManager.LoadScene("Level 4");
        }

        else
        {
            SceneManager.LoadScene("Level 5");
        }
    }

    public void nextLevel()
    {
        if(level == 1)
        {
            //level = 2;
            SceneManager.LoadScene("Level 2");
           // level = 2;
        }
        
        else if(level == 2)
        {
           // level = 3;
            SceneManager.LoadScene("Level 3");
            
        }
        
        else if(level == 3)
        {
           // level = 4;
            SceneManager.LoadScene("Level 4");
           
        }
        
        else
        {
            SceneManager.LoadScene("Level 5");
        }
        
    }
}
