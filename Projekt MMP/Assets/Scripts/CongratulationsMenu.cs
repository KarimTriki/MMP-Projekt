using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CongratulationsMenu : MonoBehaviour
{
    [SerializeField] private Text totalTime;
    void Start()
    {
        float minutes = Mathf.FloorToInt(WinMenu.totalTime / 60);
        float seconds = Mathf.FloorToInt(WinMenu.totalTime % 60);
        totalTime.text = "You Beat The Game With A Total Time Of "+string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Update is called once per frame
    public void PlayGame() {
        SceneManager.LoadScene("Level1");
        Interactables.currentLevel = 1;
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void ToStartMenu() {
        SceneManager.LoadScene("StartMenu");
    }
}
