using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static float timeValue;
    [SerializeField] private Text timerTime;

    // Update is called once per frame

    void Start() {
        timeValue = 0;
    }
    void Update()
    {
        timeValue += Time.deltaTime;
        //else {
            //Death Animation
        //}

        float minutes = Mathf.FloorToInt(timeValue / 60);
        float seconds = Mathf.FloorToInt(timeValue % 60);
        timerTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
