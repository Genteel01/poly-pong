using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaddleScoreTracker : MonoBehaviour
{
    public int score = 0;

    public Text scoreText;

    public string playerName;

    public EndGame gameEnder;

    public Settings settings;
    // Start is called before the first frame update
    void Start()
    {
        if (scoreText) scoreText.text = playerName + ": " + score;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateScore(int change)
    {
        score += change;

        if(scoreText) scoreText.text = playerName + ": " + score;

        if(score >= settings.winningScore)
        {
            gameEnder.GameEnder(playerName + " Wins!");
        }
    }
}
