using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    static Text scoreText;
    static int score = 0 ; 
    const string scorePrefix = "Points : ";
    const string ballsLeftPrefix = "Balls Left : ";
    static int balls;
    static Text ballsLeft;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        scoreText.text = scorePrefix + score;

        balls = ConfigurationUtils.MaxBalls;
        ballsLeft = GameObject.FindGameObjectWithTag("BallsLeft").GetComponent<Text>();
        ballsLeft.text = ballsLeftPrefix + balls ;

        EventManager.AddListener(AddPoints);
        EventManager.AddBallsListener(BallsLeft);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AddPoints( int points){
        score = score + points;
        scoreText.text = scorePrefix + score; 
        Debug.Log("New Points: " + score );
    }
    public static void BallsLeft(){
        balls--;
        ballsLeft.text = ballsLeftPrefix + balls;
        Debug.Log("Balls " + balls );
    }
}
