using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    [SerializeField] private Text winTitle;
    [SerializeField] private Text winTime;
    [SerializeField] private Text winLives;

    public static float totalTime;
    // Start is called before the first frame update
    void Start()
    {
        winTitle.text = "You Passed Level "+ Interactables.currentLevel;
        totalTime += Timer.timeValue;
        float minutes = Mathf.FloorToInt(Timer.timeValue / 60);
        float seconds = Mathf.FloorToInt(Timer.timeValue % 60);
        winTime.text = "Time Spent "+string.Format("{0:00}:{1:00}", minutes, seconds);
        winLives.text = "Lives Left "+ Interactables.lives.ToString();
    }

    // Update is called once per frame
    public void NextLevel() {
        if (SceneUtility.GetBuildIndexByScenePath("Level"+(Interactables.currentLevel+1).ToString()) > 0){
            SceneManager.LoadScene("Level"+(Interactables.currentLevel+1).ToString());
        }
        else {
            SceneManager.LoadScene("CongratulationsMenu");
        }
    }

    public void ReplayLevel() {
        SceneManager.LoadScene("Level"+(Interactables.currentLevel).ToString());
    }

    public void ToStartMenu() {
        SceneManager.LoadScene("StartMenu");
    }
}
