using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Settings")]
public class Settings : ScriptableObject
{
    public int numberOfPaddles = 2;
    public int numberOfPlayers = 1;

    public KeyCode[] up = { KeyCode.W, KeyCode.UpArrow, KeyCode.Keypad8, KeyCode.I, KeyCode.Home };
    public KeyCode[] down = { KeyCode.S, KeyCode.DownArrow, KeyCode.Keypad2, KeyCode.K, KeyCode.End };

    public List<GameObject> paddles;

    public List<Color> paddleColours;

    public int winningScore = 10;

    public float aiDifficulty = 1;

    [Range(0, 1)]
    public float volume = 1;
    public void ResetPaddlePositions()
    {
        foreach(GameObject g in paddles)
        {
            g.GetComponent<PaddleMovement>().ResetPosition();
        }
    }

    public void SetPaddleSpeeds()
    {
        foreach (GameObject g in paddles)
        {
            g.GetComponent<PaddleMovement>().aiPaddleSpeed = aiDifficulty;
        }
    }
}
