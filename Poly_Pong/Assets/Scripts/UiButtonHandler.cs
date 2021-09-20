using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiButtonHandler : MonoBehaviour
{
    [Tooltip("The buttons to control how many paddles there are")]
    public List<Button> paddleButtons;
    //The text objects for the above buttons
    public List<Text> paddleTexts = new List<Text>();

    [Tooltip("The buttons to control how many players there are")]
    public List<Button> playerButtons;
    //The text objects for the above buttons
    public List<Text> playerTexts = new List<Text>();

    [Tooltip("The settings object")]
    public Settings settings;
    [Tooltip("The normal colour of the button texts")]
    public Color normalColour;
    [Tooltip("The colour of selected button texts")]
    public Color selectedColour;
    [Tooltip("The text that shows the current number of points needed to win")]
    public Text pointsText;

    [Tooltip("The slider that controls the volume")]
    public Slider volumeSlider;

    [Tooltip("The buttons to control what the difficulty is")]
    public List<Button> difficultyButtons;
    //The text objects for the above buttons
    public List<Text> difficultyTexts = new List<Text>();


    [Tooltip("The buttons to control how many points you need to win")]
    public List<Button> pointsButtons;
    //The text objects for the above buttons
    public List<Text> pointsTexts = new List<Text>();
    private void Start()
    {
        foreach (Button b in paddleButtons)
        {
            paddleTexts.Add(b.GetComponentInChildren<Text>());
        }
        foreach (Button b in playerButtons)
        {
            playerTexts.Add(b.GetComponentInChildren<Text>());
        }
        foreach (Button b in difficultyButtons)
        {
            difficultyTexts.Add(b.GetComponentInChildren<Text>());
        }
        foreach (Button b in pointsButtons)
        {
            pointsTexts.Add(b.GetComponentInChildren<Text>());
        }
        UpdatePaddles(settings.numberOfPaddles);
        UpdatePlayers(settings.numberOfPlayers);
        ChangeDifficulty(settings.aiDifficulty);
        UpdateWinningScore(0);
        pointsText.text = "" + settings.winningScore;
        volumeSlider.value = settings.volume;
    }
    public void UpdatePaddles(int newAmount)
    {
        settings.numberOfPaddles = newAmount;
        //Colour the correct button
        foreach (Text t in paddleTexts)
        {
            t.color = normalColour;
        }
        paddleTexts[newAmount - 2].color = selectedColour;
        foreach (Button b in playerButtons)
        {
            b.interactable = true;
        }
        for(int i = newAmount; i < playerButtons.Count; i++)
        {
            playerButtons[i].interactable = false;
        }
        if(settings.numberOfPlayers > newAmount)
        {
            UpdatePlayers(newAmount);
        }
    }

    public void UpdatePlayers(int newAmount)
    {
        settings.numberOfPlayers = newAmount;
        //Colour the correct button
        foreach (Text t in playerTexts)
        {
            t.color = normalColour;
        }
        playerTexts[newAmount - 1].color = selectedColour;
    }
    
    public void UpdateWinningScore(int increase)
    {
        foreach (Text t in pointsTexts)
        {
            t.color = selectedColour;
        }
        settings.winningScore += increase;
        if(settings.winningScore < 1)
        {
            settings.winningScore = 1;
        }
        if(settings.winningScore == 1)
        {
            foreach (Text t in pointsTexts)
            {
                t.color = normalColour;
            }
        }
        pointsText.text = "" + settings.winningScore;
    }

    public void ChangeVolume(float value)
    {
        settings.volume = value;
    }

    public void ChangeDifficulty(float value)
    {
        settings.aiDifficulty = value;
        foreach (Text t in difficultyTexts)
        {
            t.color = normalColour;
        }
        switch(value)
        {
            case 1.5f:
                difficultyTexts[0].color = selectedColour;
                break;
            case 2f:
                difficultyTexts[1].color = selectedColour;
                break;
            case 2.5f:
                difficultyTexts[2].color = selectedColour;
                break;
        }
    }
}
