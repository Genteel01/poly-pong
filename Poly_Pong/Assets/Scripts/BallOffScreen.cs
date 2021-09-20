using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOffScreen : MonoBehaviour
{
    //public Scores scores;
    public AudioSource offScreenSound;

    public Settings settings;

    public PaddleScoreTracker lastHitPaddle;
    // Start is called before the first frame update
    void Start()
    {
        offScreenSound.volume = settings.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EndZone"))
        {
            Collider2D collider2D = GetComponent<Collider2D>();

            //// get coordinates of top-left and bottom-right of the screen (in world space, i.e. same coordinate system as GameObjects)
            //Rect screenCoords = Utils.ScreenRectInWorldCoords();

            // if off the screen, destroy self
            GetComponent<BallMovement>().RandomBallMovement();
            //scores.AddPoint(1);
            if(lastHitPaddle) lastHitPaddle.UpdateScore(1);
            offScreenSound.Play();
            //Reset the paddles
            settings.ResetPaddlePositions();
            lastHitPaddle = null;
        }
    }
    public void FixedUpdate()
    {
        //Collider2D collider2D = GetComponent<Collider2D>();

        //// get coordinates of top-left and bottom-right of the screen (in world space, i.e. same coordinate system as GameObjects)
        //Rect screenCoords = Utils.ScreenRectInWorldCoords();

        //// if off the screen, destroy self
        //if (collider2D.bounds.min.x > screenCoords.xMax)
        //{
        //    GetComponent<BallMovement>().RandomBallMovement(1);
        //    scores.AddPoint(1);
        //    offScreenSound.Play();
        //    //Reset the paddles
        //    settings.ResetPaddlePositions();
        //}
        //if (collider2D.bounds.max.x < screenCoords.xMin)
        //{
        //    GetComponent<BallMovement>().RandomBallMovement(-1);
        //    scores.AddPoint(-1);
        //    offScreenSound.Play();
        //    //Reset the paddles
        //    settings.ResetPaddlePositions();
        //}
    }

}
