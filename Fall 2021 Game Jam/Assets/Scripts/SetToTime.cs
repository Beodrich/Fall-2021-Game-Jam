using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetToTime : MonoBehaviour
{
    private TMPro.TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMPro.TMP_Text>();
        float finalTime = PlayerPrefs.GetFloat("TimeBeaten");
        text.text = "Time: " +  FloatToTimeStringSeconds(finalTime);
        text.text += "\nYou Took Down:" + PlayerPrefs.GetString("EnemiesBeaten");


    }

    public string FloatToTimeStringSeconds(float timeValue)
    {
        string finalTime = "";
        int minutes = Mathf.FloorToInt(timeValue/60);
        int seconds = Mathf.FloorToInt((timeValue) - (minutes * 60));
        float milliseconds = (timeValue - seconds - minutes * 60) * 100;
        finalTime = minutes.ToString("D1") + ":" + seconds.ToString("D2") + "." + Mathf.FloorToInt(milliseconds).ToString("D2");
        return finalTime;
    }
}
