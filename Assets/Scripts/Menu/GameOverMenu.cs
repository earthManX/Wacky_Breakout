using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    Text playerScore;
    Text highScore ; 
    // Start is called before the first frame update
    void Start()
    {
        // Pause Game
        Time.timeScale = 0 ;
        // Get HUD
        HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        // Get text components to display
        GameObject canvas = gameObject.transform.GetChild(0).gameObject;
        playerScore = canvas.transform.Find("PlayerScore").gameObject.GetComponent<Text>();
        highScore = canvas.transform.Find("HighScore").gameObject.GetComponent<Text>();
        // Display
        playerScore.text = "Your Score : " + hud.Score;
        highScore.text = "High Score : " + PlayerPrefs.GetInt("HighScore",0);

    }

    // Update is called once per frame
   

    public void OnQuitButtonClick(){
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(Menus.Main);
    }
}
