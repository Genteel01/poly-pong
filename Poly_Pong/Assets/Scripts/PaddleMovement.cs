using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public KeyCode paddleUp;
    public KeyCode paddleDown;

    public bool moveUp = true;
    public bool moveDown = true;

    public bool ai;
    public GameObject ball;
    public float aiPaddleSpeed;
    public float playerPaddleSpeed;
    private Vector2 aiMove;
    float startX, startY;

    public GameObject positionChecker;

    public GameObject topBlocker;
    public GameObject bottomBlocker;

    // Start is called before the first frame update
    void Awake()
    {
        ball = GameObject.Find("pongball");
        startX = transform.position.x;
        startY = transform.position.y;
    }

    private void Start()
    {
        if(!(transform.rotation.eulerAngles.z < 90 || transform.rotation.eulerAngles.z > 270))
        {
            KeyCode tempKeyCode = paddleUp;
            paddleUp = paddleDown;
            paddleDown = tempKeyCode;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (ball != null)
        {
            if (ai == false)
            {
                if (Input.GetKey(paddleUp))
                {
                    if (moveUp)
                    {
                        transform.Translate(new Vector3(0, 1 * playerPaddleSpeed * Time.deltaTime));
                    }
                }
                if (Input.GetKey(paddleDown))
                {
                    if (moveDown)
                    {
                        transform.Translate(new Vector3(0, -1 * playerPaddleSpeed * Time.deltaTime));
                    }
                }
            }
            //Ai movement
            else
            {
                //Reset the position checker to the paddle's position
                positionChecker.transform.position = transform.position;
                //Get the current distance between the position checker and the ball
                float currentDistance = Vector3.Distance(positionChecker.transform.position, ball.transform.position);
                //Move the position checker up in local y
                positionChecker.transform.Translate(new Vector3(0, 1));
                //If the distance between the ball and this new position is smaller than the old distance
                if(Vector3.Distance(positionChecker.transform.position, ball.transform.position) < currentDistance)
                {
                    //If the paddle hasn't hit its top wall
                    if(moveUp)
                    {
                        //Move the paddle towards this new position
                        transform.position = Vector2.MoveTowards(transform.position, positionChecker.transform.position, aiPaddleSpeed * Time.deltaTime);
                    }
                }
                else
                {
                    //Reset the position checker to the paddle's position
                    positionChecker.transform.position = transform.position;
                    //Move the position checker down in local y
                    positionChecker.transform.Translate(new Vector3(0, -1));
                    //If the distance between the ball and this new position is smaller than the old distance
                    if (Vector3.Distance(positionChecker.transform.position, ball.transform.position) < currentDistance)
                    {
                        //If the paddle hasn't hit its bottom wall
                        if (moveDown)
                        {
                            //Move the paddle towards this new position
                            transform.position = Vector2.MoveTowards(transform.position, positionChecker.transform.position, aiPaddleSpeed * Time.deltaTime);
                        }
                    }
                }
            }
        }
    }
    public void ResetPosition()
    {
        transform.position = new Vector3(startX, startY);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == topBlocker)
        {
            moveUp = false;
        }
        else if (other.gameObject == bottomBlocker)
        {
            moveDown = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == topBlocker)
        {
            moveUp = true;
        }
        else if (other.gameObject == bottomBlocker)
        {
            moveDown = true;
        }
    }
}
