using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float timeValue;
    [SerializeField] private Text timerTime;

    void Start() {
        timeValue = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeValue += Time.deltaTime;
        //else {
            //Death Animation
        //}

        DisplayTime(timeValue);
    }

    public void DisplayTime(float time) {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        timerTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
