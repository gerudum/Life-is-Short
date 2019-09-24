using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text livesLeft;
    public Transform spawnPoint;

    public GameObject player;
    public GameObject gameOver;
    public GameObject levelComplete;

    public int keys = 0;
    public int requiredKeys = 0;
    public int lives = 2;
    public int maxLives = 2;

    public void Awake()
    {
        instance = this;        
    }

    public void Start()
    {
        string level = SceneManager.GetActiveScene().name;
        if (level.Contains("Level") && !level.Contains("Select"))
        {
            NextLife();
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        } else if (Input.GetKeyDown(KeyCode.Q))
        {
            LoadLevel("Level-Select");
        }
    }
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

        GameObject newPlayer = Instantiate(player, spawnPoint.position, spawnPoint.rotation);
    }

    public int levelIndex;
    public void CompleteLevel()
    {
        levelComplete.SetActive(true);
        PlayerPrefs.SetInt("Unlocked_" + levelIndex.ToString(), 1);
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
