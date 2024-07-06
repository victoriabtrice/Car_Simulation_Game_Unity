using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float startTime;
    private bool isMove;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.realtimeSinceStartup;
        isMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            float elapsedTime = Time.realtimeSinceStartup - startTime;            
            int hours = (int)(elapsedTime / 3600);            
            int minutes = (int)((elapsedTime % 3600) / 60);
            int seconds = (int)(elapsedTime % 60);
            PlayerPrefs.SetInt("HoursTime", hours);
            PlayerPrefs.SetInt("MinutesTime", minutes);
            PlayerPrefs.SetInt("SecondsTime", seconds);
        }
        // else if(Time.timeScale = 0)
        // {
        //     isMove = false;
        // }
    }
    
    // Call this method when all movement stops    
    public void StopMovement()
    {
        isMove = false;
    }
}
