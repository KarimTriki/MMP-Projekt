using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CongratulationsMenu : MonoBehaviour
{
    //The placeholder text that will display the total time
    [SerializeField] private Text totalTime;
    void Start()
    {
        //Display the total time spent playing through all levels
        float minutes = Mathf.FloorToInt(WinMenu.totalTime / 60);
        float seconds = Mathf.FloorToInt(WinMenu.totalTime % 60);
        totalTime.text = "You Beat The Game With A Total Time Of "+string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    //Restart from Level1
    public void RestartGame() {
        SceneManager.LoadScene("Level1");
        Interactables.currentLevel = 1;
    }

    //Quit
    public void QuitGame() {
        Application.Quit();
    }

    //Load Start Menu
    public void ToStartMenu() {
        SceneManager.LoadScene("StartMenu");
    }
}
