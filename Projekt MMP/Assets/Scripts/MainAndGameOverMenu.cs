using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainAndGameOverMenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void ToStartMenu() {
        SceneManager.LoadScene("StartMenu");
    }

    public void PlayTutorial() {
        SceneManager.LoadScene("Tutorial");
    }
}
