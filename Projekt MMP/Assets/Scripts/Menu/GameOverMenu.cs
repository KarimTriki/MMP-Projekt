using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    //Restart from Level1
    public void RestartGame() {
        SceneManager.LoadScene("Level1");
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
