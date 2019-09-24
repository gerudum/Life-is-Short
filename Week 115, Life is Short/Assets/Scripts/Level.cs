using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Level : MonoBehaviour
{
    private GameManager gm;
    public void Start()
    {
        gm = GameManager.instance;

        //Keeping track of what levels the player has completed
        int previous = levelIndex - 1;
        if(previous <= 0)
        {
            previous = 0;
        }
        lastLevel = PlayerPrefs.GetInt("Unlocked_" +previous.ToString(), 0);
        unlocked = PlayerPrefs.GetInt("Unlocked_" + levelIndex.ToString(),0);
        level.text = levelIndex.ToString();

        //Changing button color accordingly
        image = GetComponent<Image>();

        if(unlocked != 0)
        {
            image.color = Color.green;
        } else if (lastLevel !=0 ) {
            image.color = Color.grey;
        } else
        {
            image.color = Color.red;
        }
    }

    private int lastLevel = 0;
    private int unlocked = 0;
    public int levelIndex = 0;
    

    public Text level;
    private Image image;

    //Play the level
    public void PlayLevel()
    {
        if (unlocked != 0 || lastLevel != 0)
        {
            gm.LoadLevel("Level-"+levelIndex.ToString());
        }
    }
}
