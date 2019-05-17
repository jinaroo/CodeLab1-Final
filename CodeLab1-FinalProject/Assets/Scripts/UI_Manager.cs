using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;

    public Text scoreText;
    public Text highScoreText;
    
    // saving high scores (player preferences)
    private const string PLAYER_PREF_HIGHSCORE = "highScore";
    private int score = 0;
    private int highScore = 0;

    public int Score // property
    {
        get { return score; }
        set
        {
            score = value;
            scoreText.text = "score: " + score;

            HighScore = score;
        }
    }

    public int HighScore
    {
        get { return highScore; }
        set
        {
            if (value > highScore)
            {
                highScore = value;
                highScoreText.text = "high score: " + highScore;

                PlayerPrefs.SetInt(PLAYER_PREF_HIGHSCORE, highScore);
            }
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        // cont. high scores
        Score = 0;
        HighScore = PlayerPrefs.GetInt(PLAYER_PREF_HIGHSCORE, 10); // default value
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
