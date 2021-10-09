using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenuUI;
    void start()
    {

    }
    public bool Pause = false; 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Pause == false)

        {
            Time.timeScale = 0;
                Pause = true;
              pauseMenuUI.SetActive(true)  ;

        }
else if (Input.GetKeyDown(KeyCode.Escape) && Pause == true)
{
    Time.timeScale = 1;

    Pause = false; 
   
  pauseMenuUI.SetActive(false)  ;
}

        
    }
}
