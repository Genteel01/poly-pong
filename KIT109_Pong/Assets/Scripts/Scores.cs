using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    public int leftScore = 0;
    public int rightScore = 0;

    public Text leftText;
    public Text rightText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint(int player)
    {
        if (player < 0)
        {
            rightScore += 1;
        }
        else
        {
            leftScore += 1;
        }
    }

    public void OnGUI()
    {
        leftText.text = "" + leftScore;
        rightText.text = "" + rightScore;
    }
}
