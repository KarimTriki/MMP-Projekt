using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    //Placeholder text to Display what Level the player completed
    [SerializeField] private Text winTitle;

    //Placeholder text to Display the Time it took to complete the current level
    [SerializeField] private Text winTime;

    //Placeholder text to Display the remaining Lives the player has
    [SerializeField] private Text winLives;

    //The total time to be displayed when the player finishes the game
    public static float totalTime;
    
    void Start()
    {
        //Display Level
        winTitle.text = "You Passed Level "+ Interactables.currentLevel;

        //Display Time
        float minutes = Mathf.FloorToInt(Timer.timeValue / 60);
        float seconds = Mathf.FloorToInt(Timer.timeValue % 60);
        winTime.text = "Time Spent "+string.Format("{0:00}:{1:00}", minutes, seconds);

        //Display Lives
        winLives.text = "Lives Left "+ Interactables.lives.ToString();
    }

    //Loads next level. If there is no next level, load CongratulationsMenu
    public void NextLevel() {

        //Add current level time to the total time
        totalTime += Timer.timeValue;

        if (SceneUtility.GetBuildIndexByScenePath("Level"+(Interactables.currentLevel+1).ToString()) > 0){
            SceneManager.LoadScene("Level"+(Interactables.currentLevel+1).ToString());
        }
        else {
            SceneManager.LoadScene("CongratulationsMenu");
        }
    }

    //Load the same level and reset the player lives to where they were at the start of the level
    public void ReplayLevel() {
        Interactables.lives = Interactables.startingLives;
        SceneManager.LoadScene("Level"+(Interactables.currentLevel).ToString());
    }

    //Load Start Menu
    public void ToStartMenu() {
        SceneManager.LoadScene("StartMenu");
    }
}
