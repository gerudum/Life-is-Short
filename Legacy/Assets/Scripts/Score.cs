using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text highScore;
    public Text score;
    public float points;
    public void Start()
    {

        highScore.text = PlayerPrefs.GetFloat("HighScore", 0).ToString();
    }
    public void FixedUpdate()
    {
        if(player != null)
        {
            score.text = points.ToString();
        } else
        {
            if(float.Parse(score.text) > PlayerPrefs.GetFloat("HighScore"))
            {
                PlayerPrefs.SetFloat("HighScore", float.Parse(score.text));
            }
        }
    }
}
