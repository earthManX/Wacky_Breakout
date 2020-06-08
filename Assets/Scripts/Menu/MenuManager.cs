using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class MenuManager 
{
      
    public static void GoToMenu( Menus menuName ){
        switch( menuName ){
            case Menus.Main:
                SceneManager.LoadScene("MainMenu");
                break;
            case Menus.Pause:
                Object.Instantiate(Resources.Load("PauseMenu"));
                break;
            case Menus.Help:
                break;
            case Menus.GameOver:
                Object.Instantiate(Resources.Load("GameOver"));
                break;
            default:
                break;

        }
    }
}
