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
        minAngle = paddleOffset * -0.75f;
        maxAngle = paddleOffset * 0.75f;
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
        if (other.CompareTag("Player"))
        {
            speed *= accelleration;
            transform.rotation = other.transform.rotation;
            transform.Rotate(0, 0, paddleOffset);
            transform.Rotate(0, 0, Random.Range(minAngle, maxAngle));

            ballHitPaddle.Play();
            offScreenManager.lastHitPaddle = other.GetComponent<PaddleScoreTracker>();
        }
        if (other.CompareTag("Top") || other.CompareTag("Bottom"))
        {
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
