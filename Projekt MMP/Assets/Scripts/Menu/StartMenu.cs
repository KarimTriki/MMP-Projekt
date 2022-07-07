using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    //Start from Level1
    public void PlayGame() {
        SceneManager.LoadScene("Level1");
    }

    //Quit
    public void QuitGame() {
        Application.Quit();
    }

    //Load Tutorial
    public void PlayTutorial() {
        SceneManager.LoadScene("Tutorial");
    }
}
