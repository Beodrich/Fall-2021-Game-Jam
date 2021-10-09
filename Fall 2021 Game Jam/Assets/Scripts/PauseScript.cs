using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{

    public bool Pause = false; 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Pause == false)

        {
Time.timeScale = 0;
Pause = true;

        }
if (Input.GetKeyDown(KeyCode.Escape) && Pause == true)
{
    Time.timeScale = 1;

    Pause = false; 

}

        
    }
}
