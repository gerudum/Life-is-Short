using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    //Lives left
    public Text livesLeft;

    //Where the player spawns
    public Transform spawnPoint;

    //GameOver,LevelComplete,and Player references
    public GameObject player;
    public GameObject gameOver;
    public GameObject levelComplete;

    //Keys
    public int keys = 0;

    //Keys needed in a given level
    public int requiredKeys = 0;

    //lives
    public int lives = 2;
    public int maxLives = 2;

    public void Awake()
    {
        instance = this;        
    }

    public void Start()
    {
        //Checking if this scene is a level or not
        string level = SceneManager.GetActiveScene().name;
        if (level.Contains("Level") && !level.Contains("Select"))
        {
            NextLife();
        }
    }

    public void Update()
    {
        //Restart and Load Levels
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        } else if (Input.GetKeyDown(KeyCode.Q))
        {
            LoadLevel("Level-Select");
        }

        //ClearData shortcut TODO: Remove this in final builds
        if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.E) && Input.GetKey(KeyCode.L))
        {
            for(int i = 1; i < 11; i++)
            {
                PlayerPrefs.SetInt("Unlocked_" + i.ToString(), 0);
            }
        }
    }

    //When you die move on to the next life
    public void NextLife()
    {
        lives -= 1;
        livesLeft.text = "x"+lives.ToString();

        if(lives < 0)
        {
            Debug.Log("You Failed!");
            GameOver();
            return;
        }

        //New player
        GameObject newPlayer = Instantiate(player, spawnPoint.position, spawnPoint.rotation);
    }

    //Completing a level
    public int levelIndex;
    public void CompleteLevel()
    {
        levelComplete.SetActive(true);
        PlayerPrefs.SetInt("Unlocked_" + levelIndex.ToString(), 1);
    }

    //Gameover
    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    //Quit for standalone builds, all though this is an html game won't be needed
    public void Quit()
    {
        Application.Quit();
    }

    //NextLevel
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Restart current level
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Load a specific Level
    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
