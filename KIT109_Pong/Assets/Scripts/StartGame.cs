using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartOnePlayer()
    {
        SceneManager.LoadScene("Pong");
    }

    public void StartTwoPlayers()
    {
        SceneManager.LoadScene("Pong2");
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
