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

    public int lives = 2;
    public int maxLives = 2;

    public void Awake()
    {
        instance = this;        
    }

    public void Start()
    {
        NextLife();
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

    public void CompleteLevel()
    {
        levelComplete.SetActive(true);
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
