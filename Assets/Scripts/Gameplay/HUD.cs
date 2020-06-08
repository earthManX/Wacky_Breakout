using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    static Text scoreText;
    static int score ; 
    const string scorePrefix = "Points : ";
    const string ballsLeftPrefix = "Balls Left : ";
    static int balls;
    static Text ballsLeft;
    static int highScore  = 0 ;
    // Start is called before the first frame update

    public int Score{
        get{ return score ;} 
    }
    void Start()
    {
        score = 0 ;
        scoreText = GameObject.FindGameObjectWithTag("ScoreText").GetComponent<Text>();
        scoreText.text = scorePrefix + score;

        balls = ConfigurationUtils.MaxBalls;
        ballsLeft = GameObject.FindGameObjectWithTag("BallsLeft").GetComponent<Text>();
        ballsLeft.text = ballsLeftPrefix + balls ;

        EventManager.AddListener(AddPoints);
        EventManager.AddBallsListener(BallsLeft);

        highScore = PlayerPrefs.GetInt("HighScore" , 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void AddPoints( int points){
        score = score + points;
        scoreText.text = scorePrefix + score; 
        if( score > highScore ){
            highScore = score ;
            Debug.Log("New High Points: " + score ); 
        }

    }
    public static void BallsLeft(){
        balls--;
        ballsLeft.text = ballsLeftPrefix + balls;
        Debug.Log("Balls " + balls );
        // Quit when no balls are left
        if( balls == 0 ){
            PlayerPrefs.SetInt("HighScore"  , highScore );
            PlayerPrefs.Save();
            MenuManager.GoToMenu(Menus.GameOver);
        }
    }
}
