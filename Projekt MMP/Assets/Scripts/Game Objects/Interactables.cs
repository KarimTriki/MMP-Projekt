using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interactables : MonoBehaviour
{
    public PlayerMovement pMov;

    public static bool died = false;

    //Player lives at the start of the game
    private float resetLives = 5;

    //current player lives
    public static float lives;

    //Player lives at the start of the level
    public static float startingLives;

    //Current collected coins and max coins needed to pass the level
    private float maxCoins;
    private float coins;

    //Current level
    public static float currentLevel;

    //Placeholder texts for the UI
    [SerializeField] private Text textCoins;
    [SerializeField] private Text textLives;
    [SerializeField] private Text textLevel;

    //Panel to display how many missing coins left to collect
    [SerializeField] private GameObject coinsPanel;
    [SerializeField] private Text coinsRemaining;
    private float panelTimer = 3f;
    private float panelCooldownTimer;

    //Various sound effecs
    [SerializeField] AudioSource collectCoinSound;
    [SerializeField] AudioSource collectLifeSound;
    [SerializeField] AudioSource dieSound;
    [SerializeField] AudioSource finishSound;

    void Start() {
        if(SceneManager.GetActiveScene().name == "Level1" || SceneManager.GetActiveScene().name == "Tutorial" ) {
            lives = resetLives;
        }
        startingLives = lives;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        coins = 0;
        maxCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        textCoins.text = coins.ToString()+'/'+maxCoins.ToString();
        textLives.text = lives.ToString();
        if (SceneManager.GetActiveScene().name == "Tutorial") {
            textLevel.text = "TUTORIAL";
        }
        else {
            textLevel.text = "LEVEL "+currentLevel.ToString();
        }
        panelCooldownTimer = panelTimer;
    }

    void Update() {
        //Escape in the Tutorial loads the Start Menu
        if(Input.GetKey(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Tutorial") {
            SceneManager.LoadScene("StartMenu");
        }

        //If the coins panel is activated, leave it activated for (panelTimer) seconds and then deactivate it and reset the panelCooldownTimer
        if (coinsPanel.activeSelf) {
            panelCooldownTimer -= Time.deltaTime;
            if (panelCooldownTimer > 0) {
                return;
            }
        }
        coinsPanel.SetActive(false);
        panelCooldownTimer = panelTimer;
    }
    private void OnTriggerEnter2D(Collider2D obj) {

        //Coin Collecting
        if(obj.transform.tag == "Coin"){
            coins++;
            Destroy(obj.gameObject);
            textCoins.text = coins.ToString()+'/'+maxCoins.ToString();
            if (VolumeManager.isOn) {
                collectCoinSound.Play();
            }
        }

        //Life collecting
        if(obj.transform.tag == "Life"){
            if (SceneManager.GetActiveScene().name != "Tutorial"){
                    lives++;
            }
            Destroy(obj.gameObject);
            textLives.text = lives.ToString();
            if (VolumeManager.isOn) {
                collectLifeSound.Play();
            }
        }

        //Colliding with enemies
        if(obj.transform.tag == "Enemy" || obj.transform.tag == "EnemyOrLift"){
            if (SceneManager.GetActiveScene().name != "Tutorial"){
                    lives--;
            }
            
            textLives.text = lives.ToString();
            if (lives > 0) {
                this.transform.position = PlayerMovement.startingPosition;
                if (VolumeManager.isOn) {
                    dieSound.Play();
                }
                died = true;
            } 
            else if (lives <= 0) {
                SceneManager.LoadScene("GameOverMenu");
            }
        }
        
        //Reaching finish line
        if(obj.transform.tag == "Finish"){
            if (coins == maxCoins) {
                if (SceneManager.GetActiveScene().name == "Tutorial"){
                    SceneManager.LoadScene("StartMenu");
                }
                else {
                    SceneManager.LoadScene("WinMenu");
                }
            }
            else {
                coinsRemaining.text = "You Need To Collect The Remaining "+ (maxCoins - coins).ToString() + " Coin(s)";
                coinsPanel.SetActive(true);

            }
        }

        //Stepping on a trampoline
        if(obj.transform.tag == "Trampoline"){
            pMov.Trampolining();
        }

    }
    
}