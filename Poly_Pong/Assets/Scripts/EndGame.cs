using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    //public Scores scorer;
    public Text victoryText;
    public Text playAgain;
    public GameObject ball;
    public Button playAgainButton;
    public Button backToMenuButton;
    public Text backToMenuText;


    public AudioSource endGameNoise;

    public Settings settings;
    private void Start()
    {
        endGameNoise.volume = settings.volume;
    }

    public void GameEnder(string winText)
    {
        victoryText.text = winText;
        Destroy(ball);
        playAgain.text = "Play Again?";
        playAgainButton.interactable = true;
        backToMenuText.text = "Back To Menu";
        backToMenuButton.interactable = true;
        endGameNoise.Play();
    }
}
