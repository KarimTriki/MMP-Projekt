using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script to store and display the time spent inside a level
public class Timer : MonoBehaviour
{
    //The time spent
    public static float timeValue;

    //Placeholder text to display Time
    [SerializeField] private Text timerTime;

    void Start() {
        //At the start of each level Time is set to 0
        timeValue = 0f;
    }

    void Update()
    {
        //Time increased by deltaTime
        timeValue += Time.deltaTime;

        //Display the time in a 00:00 format
        DisplayTime(timeValue);
    }

    public void DisplayTime(float time) {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timerTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
