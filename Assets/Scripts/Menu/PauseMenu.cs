using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Stops everything
        Time.timeScale = 0 ;
    }

    public void ResumeButtonClick(){
        Time.timeScale = 1 ;
        Destroy(gameObject);
    }

    public void QuitButtonClick(){
        Time.timeScale = 1;
        Destroy(gameObject);
        MenuManager.GoToMenu(Menus.Main);
    }
    
}
