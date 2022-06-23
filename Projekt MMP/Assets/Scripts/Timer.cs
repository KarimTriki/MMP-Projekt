using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timeValue;
    [SerializeField] private Text timerTime;

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0){
            timeValue -= Time.deltaTime;
        }
        //else {
            //Death Animation
        //}

        DisplayTime(timeValue);
    }

    void DisplayTime(float time) {
        if (time < 0) {
            time = 0;
        }

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timerTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
