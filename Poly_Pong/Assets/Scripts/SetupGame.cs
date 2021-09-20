using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupGame : MonoBehaviour
{
    [Tooltip("The settings scriptableobject")]
    public Settings settings;
    [Tooltip("The prefab for the paddles")]
    public GameObject paddlePrefab;
    [Tooltip("The prefab for the top wall")]
    public GameObject topPrefab;
    [Tooltip("The prefab for the bottom wall")]
    public GameObject bottomPrefab;
    [Tooltip("The prefab for the top blockers (when there are more than 2 paddles")]
    public GameObject smallTopPrefab;
    [Tooltip("The prefab for the bottom blockers (when there are more than 2 paddles")]
    public GameObject smallBottomPrefab;

    [Tooltip("The prefab for the end zones")]
    public GameObject endZonePrefab;

    [Tooltip("The prefab for the score texts")]
    public GameObject scoreTextPrefab;

    [Tooltip("The game end manager")]
    public EndGame gameEnder;

    public float[] sideLengths { get; set; } = { 0, 0, 0, 4.5f, 4.5f, 2.8f, 2.3f, 2f, 1.88f };

    // Start is called before the first frame update
    void Start()
    {
        settings.paddles =  new List<GameObject>();
        CreatePaddles(settings.numberOfPaddles, settings.numberOfPlayers);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void CreatePaddles(int numberOfPaddles, int numberOfPlayers)
    //{
    //    int angle = 0;
    //    Vector2[] positionArray;
    //    switch(numberOfPaddles)
    //    {
    //        case 2:
    //            positionArray = settings.paddlePositions2;
    //            break;
    //        case 3:
    //            positionArray = settings.paddlePositions3;
    //            break;
    //        case 4:
    //            positionArray = settings.paddlePositions4;
    //            break;
    //        case 5:
    //            positionArray = settings.paddlePositions5;
    //            break;
    //        default:
    //            positionArray = settings.paddlePositions2;
    //            break;
    //    }
    //    //Set up the player's paddles
    //    for(int i = 0; i < numberOfPlayers; i++)
    //    {
    //        //Set the angle of the paddle based on how many paddles there will be (i.e. how many sides to the shape there will be).
    //        Quaternion paddleRotation = new Quaternion();
    //        paddleRotation.eulerAngles = new Vector3(0, 0, (angle % 180));
    //        angle += 360 / numberOfPaddles;
    //        //Make a new paddle.
    //        GameObject newPaddle = (GameObject)Instantiate(paddlePrefab, positionArray[i], paddleRotation);
    //        PaddleMovement paddleController = newPaddle.GetComponent<PaddleMovement>();
    //        paddleController.ai = false;
    //        paddleController.paddleUp = settings.up[i];
    //        paddleController.paddleDown = settings.down[i];
    //        //If there are more than 2 paddles, create invisible walls to stop the paddle from moving too far to each side.
    //        //If there are only 2 paddles this function will be performed by the top and bottom walls that the ball bounces off.
    //        if(numberOfPaddles > 2)
    //        {
    //            //Move the position checker object to the top of its side, create a wall at its position, move it to the bottom, create another wall, and move it back to the start.
    //            paddleController.positionChecker.transform.Translate(new Vector3(0, sideLengths[numberOfPaddles]));
    //            GameObject topWall = (GameObject)Instantiate(smallTopPrefab, paddleController.positionChecker.transform.position, paddleRotation);
    //            paddleController.positionChecker.transform.Translate(new Vector3(0, sideLengths[numberOfPaddles] * -2));
    //            GameObject bottomWall = (GameObject)Instantiate(smallBottomPrefab, paddleController.positionChecker.transform.position, paddleRotation);
    //            paddleController.positionChecker.transform.Translate(new Vector3(0, sideLengths[numberOfPaddles]));
    //        }
    //        //Add the paddle to the list of paddles
    //        settings.paddles.Add(newPaddle);
    //    }
    //    //Set up the ai paddles
    //    for(int i = numberOfPlayers; i < numberOfPaddles; i++)
    //    {
    //        //Set the angle of the paddle based on how many paddles there will be (i.e. how many sides to the shape there will be).
    //        Quaternion paddleRotation = new Quaternion();
    //        paddleRotation.eulerAngles = new Vector3(0, 0, (angle%180));
    //        angle += 360 / numberOfPaddles;
    //        //Make a new paddle.
    //        GameObject newPaddle = (GameObject)Instantiate(paddlePrefab, positionArray[i], paddleRotation);
    //        PaddleMovement paddleController = newPaddle.GetComponent<PaddleMovement>();
    //        paddleController.ai = true;
    //        //If there are more than 2 paddles, create invisible walls to stop the paddle from moving too far to each side.
    //        //If there are only 2 paddles this function will be performed by the top and bottom walls that the ball bounces off.
    //        if (numberOfPaddles > 2)
    //        {
    //            //Move the position checker object to the top of its side, create a wall at its position, move it to the bottom, create another wall, and move it back to the start.
    //            paddleController.positionChecker.transform.Translate(new Vector3(0, sideLengths[numberOfPaddles]));
    //            GameObject topWall = (GameObject)Instantiate(smallTopPrefab, paddleController.positionChecker.transform.position, paddleRotation);
    //            paddleController.positionChecker.transform.Translate(new Vector3(0, sideLengths[numberOfPaddles] * -2));
    //            GameObject bottomWall = (GameObject)Instantiate(smallBottomPrefab, paddleController.positionChecker.transform.position, paddleRotation);
    //            paddleController.positionChecker.transform.Translate(new Vector3(0, sideLengths[numberOfPaddles]));
    //        }
    //        //Add the paddle to the list of paddles
    //        settings.paddles.Add(newPaddle);
    //    }
    //    //Special case to create the walls if it is a 2 player game
    //    if(numberOfPaddles == 2)
    //    {
    //        Instantiate(topPrefab, new Vector2(0, 4), Quaternion.Euler(0, 0, 90));
    //        Instantiate(bottomPrefab, new Vector2(0, -4), Quaternion.Euler(0, 0, 90));
    //    }
    //}

    void CreatePaddles(int numberOfPaddles, int numberOfPlayers)
    {
        float radius = 0.8f * numberOfPaddles * 0.7f;
        float dTheta = (Mathf.PI * 2) / numberOfPaddles;

        float blockerOffset = radius * 0.5f;
        switch(numberOfPaddles)
        {
            case 3:
                blockerOffset = (radius / Mathf.Sin(dTheta)) * 2 * Mathf.Cos(dTheta) * -1.5f;
                break;
            case 4:
                blockerOffset = radius;
                break;
            case 5:
                blockerOffset = radius * 0.725f;
                break;
            case 6:
                blockerOffset = radius * 0.58f;
                break;
            case 7:
                blockerOffset = radius * 0.48f;
                break;
            case 8:
                blockerOffset = radius * 0.415f;
                break;
        }
        //Set up the player's paddles
        for (int i = 0; i < numberOfPlayers; i++)
        {
            float theta = i * dTheta;
            //Set the angle of the paddle based on how many paddles there will be (i.e. how many sides to the shape there will be).
            Quaternion paddleRotation = new Quaternion();
            paddleRotation.eulerAngles = new Vector3(0, 0, theta * Mathf.Rad2Deg);
            //Make a new paddle.
            GameObject newPaddle = (GameObject)Instantiate(paddlePrefab, new Vector2(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta)), paddleRotation);
            PaddleMovement paddleController = newPaddle.GetComponent<PaddleMovement>();
            paddleController.ai = false;
            paddleController.paddleUp = settings.up[i];
            paddleController.paddleDown = settings.down[i];
            //If there are more than 2 paddles, create invisible walls to stop the paddle from moving too far to each side.
            //If there are only 2 paddles this function will be performed by the top and bottom walls that the ball bounces off.
            if (numberOfPaddles > 2)
            {
                //Move the position checker object to the top of its side, create a wall at its position, move it to the bottom, create another wall, and move it back to the start.
                paddleController.positionChecker.transform.Translate(new Vector3(0, blockerOffset));
                GameObject topWall = (GameObject)Instantiate(smallTopPrefab, paddleController.positionChecker.transform.position, paddleRotation);
                paddleController.topBlocker = topWall;
                paddleController.positionChecker.transform.Translate(new Vector3(0, blockerOffset * -2));
                GameObject bottomWall = (GameObject)Instantiate(smallBottomPrefab, paddleController.positionChecker.transform.position, paddleRotation);
                paddleController.bottomBlocker = bottomWall;
                paddleController.positionChecker.transform.Translate(new Vector3(0, blockerOffset));
            }
            //Add the paddle to the list of paddles
            settings.paddles.Add(newPaddle);
            newPaddle.GetComponent<SpriteRenderer>().color = settings.paddleColours[i];
            //Set up the paddle's score controller
            PaddleScoreTracker scoreController = newPaddle.GetComponent<PaddleScoreTracker>();
            scoreController.playerName = "Player " + (i + 1);
            scoreController.gameEnder = gameEnder;
            scoreController.settings = settings;
            //Make a new end zone
            Instantiate(endZonePrefab, new Vector2((radius + 2) * Mathf.Cos(theta), (radius + 2) * Mathf.Sin(theta)), paddleRotation);
        }
        //Set up the ai paddles
        for (int i = numberOfPlayers; i < numberOfPaddles; i++)
        {
            float theta = i * dTheta;
            //Set the angle of the paddle based on how many paddles there will be (i.e. how many sides to the shape there will be).
            Quaternion paddleRotation = new Quaternion();
            paddleRotation.eulerAngles = new Vector3(0, 0, theta * Mathf.Rad2Deg);
            //Make a new paddle.
            GameObject newPaddle = (GameObject)Instantiate(paddlePrefab, new Vector2(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta)), paddleRotation);
            PaddleMovement paddleController = newPaddle.GetComponent<PaddleMovement>();
            paddleController.ai = true;
            //If there are more than 2 paddles, create invisible walls to stop the paddle from moving too far to each side.
            //If there are only 2 paddles this function will be performed by the top and bottom walls that the ball bounces off.
            if (numberOfPaddles > 2)
            {
                //Move the position checker object to the top of its side, create a wall at its position, move it to the bottom, create another wall, and move it back to the start.
                paddleController.positionChecker.transform.Translate(new Vector3(0, blockerOffset));
                GameObject topWall = (GameObject)Instantiate(smallTopPrefab, paddleController.positionChecker.transform.position, paddleRotation);
                paddleController.topBlocker = topWall;
                paddleController.positionChecker.transform.Translate(new Vector3(0, blockerOffset * -2));
                GameObject bottomWall = (GameObject)Instantiate(smallBottomPrefab, paddleController.positionChecker.transform.position, paddleRotation);
                paddleController.bottomBlocker = bottomWall;
                paddleController.positionChecker.transform.Translate(new Vector3(0, blockerOffset));
            }
            //Add the paddle to the list of paddles
            settings.paddles.Add(newPaddle);
            newPaddle.GetComponent<SpriteRenderer>().color = settings.paddleColours[i];
            //Set up the paddle's score controller
            PaddleScoreTracker scoreController = newPaddle.GetComponent<PaddleScoreTracker>();
            scoreController.playerName = "Ai " + (i + 1);
            scoreController.gameEnder = gameEnder;
            scoreController.settings = settings;
            //Make a new end zone
            Instantiate(endZonePrefab, new Vector2(radius * 3 * Mathf.Cos(theta), radius * 3 * Mathf.Sin(theta)), paddleRotation);
        }
        //Special case to create the walls if it is a 2 player game
        if (numberOfPaddles == 2)
        {
            Instantiate(topPrefab, new Vector2(0, 4), Quaternion.Euler(0, 0, 90));
            Instantiate(bottomPrefab, new Vector2(0, -4), Quaternion.Euler(0, 0, 90));
        }
    }
}
