using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public AudioSource ballHitWall;
    public AudioSource ballHitPaddle;

    [Tooltip("Handles the ball going off screen")]
    public BallOffScreen offScreenManager;

    [Tooltip("The settings object")]
    public Settings settings;

    float paddleOffset;
    float minAngle;
    float maxAngle;

    public float speed = 2f;

    [Tooltip("How much the ball speeds up each time it hits a paddle")]
    public float accelleration = 1.02f;
    private void Awake()
    {
        paddleOffset = (Mathf.PI * 2) / settings.numberOfPaddles;
        paddleOffset *= Mathf.Rad2Deg;
        if (settings.numberOfPaddles == 2)
        {
            paddleOffset *= 0.5f;
            minAngle = paddleOffset * -0.7f;
            maxAngle = paddleOffset * 0.7f;
        }
        else if (settings.numberOfPaddles == 3)
        {
            minAngle = paddleOffset * -0.5f;
            maxAngle = paddleOffset * 0.5f;
        }
        else
        {
            minAngle = paddleOffset * -0.7f;
            maxAngle = paddleOffset * 0.7f;
        }

        ballHitWall.volume = settings.volume;
        ballHitPaddle.volume = settings.volume;

    }
    // Start is called before the first frame update
    void Start()
    {
        RandomBallMovement();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(1 * ballSpeed.x * Time.deltaTime, 1 * ballSpeed.y * Time.deltaTime));
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //float yDifference;
        speed *= accelleration;
        if (other.CompareTag("Player"))
        {
            transform.rotation = other.transform.rotation;
            transform.Rotate(0, 0, paddleOffset);
            transform.Rotate(0, 0, Random.Range(minAngle, maxAngle));

            ballHitPaddle.Play();
            offScreenManager.lastHitPaddle = other.GetComponent<PaddleScoreTracker>();
        }
        else if (other.CompareTag("Top"))
        {
            if(transform.rotation.eulerAngles.z < 180)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 135));
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 225));
            }
            ballHitWall.Play();
        }
        else if(other.CompareTag("Bottom"))
        {
            if (transform.rotation.eulerAngles.z < 180)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 45));
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 315));
            }
            ballHitWall.Play();
        }
    }

    public void RandomBallMovement()
    {
        transform.Rotate(0, 0, Random.Range(0, 360));
        transform.position = new Vector2(0, 0);
    }

    public void RandomBallMovement(int xDirection)
    {
        transform.Rotate(0, 0, Random.Range(0, 360));
        transform.position = new Vector2(0, 0);
    }

}
