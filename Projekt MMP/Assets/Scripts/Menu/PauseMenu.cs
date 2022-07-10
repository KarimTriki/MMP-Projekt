using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool paused = false;

    //Pause Menu UI
    [SerializeField] private GameObject pauseMenuUI;

    void Update(){
        //Tutorial doesn't have a Pause Menu
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "Tutorial") {
            if (paused) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    //Activate Pause Menu and freeze time
    void Pause () {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    //Deactivate Pause Menu and set time back to normal
    public void Resume () {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    //Quit
    public void QuitGame() {
        Application.Quit();
    }

    //Set time back to normal and load Start Menu
    public void ToStartMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }
}
