using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interactables : MonoBehaviour
{
    public PlayerMovement pMov;
    [SerializeField] private float maxCoins;
    public static float lives = 5;
    public static bool died = false;
    private float coins;
    public static float currentLevel;
    [SerializeField] private Text textCoins;
    [SerializeField] private Text textLives;

    [SerializeField] private GameObject coinsPanel;

    [SerializeField] private Text coinsRemaining;
    private float panelTimer = 3f;
    private float panelCooldownTimer;

    [SerializeField] AudioSource collectCoinSound;
    [SerializeField] AudioSource collectLifeSound;

    [SerializeField] AudioSource dieSound;
    [SerializeField] AudioSource finishSound;

    void Start() {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        coins = 0;
        textCoins.text = coins.ToString()+'/'+maxCoins.ToString();
        textLives.text = lives.ToString();
        panelCooldownTimer = panelTimer;
    }

    void Update() {
        if (coinsPanel.activeSelf) {
            panelCooldownTimer -= Time.deltaTime;
            if (panelCooldownTimer > 0) {
                return;
            }
        }
        coinsPanel.SetActive(false);
        panelCooldownTimer = panelTimer;

        if(Input.GetKey(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Tutorial") {
            SceneManager.LoadScene("StartMenu");
        }
    }
    private void OnTriggerEnter2D(Collider2D collectable) {
        if(collectable.transform.tag == "Coin"){
            coins++;
            Destroy(collectable.gameObject);
            textCoins.text = coins.ToString()+'/'+maxCoins.ToString();
            if (VolumeManager.isOn) {
                collectCoinSound.Play();
            }
        }
        if(collectable.transform.tag == "Life"){
            if (SceneManager.GetActiveScene().name != "Tutorial"){
                    lives++;
            }
            Destroy(collectable.gameObject);
            textLives.text = lives.ToString();
            if (VolumeManager.isOn) {
                collectLifeSound.Play();
            }
        }
        if(collectable.transform.tag == "Enemy"){
            if (SceneManager.GetActiveScene().name != "Tutorial"){
                    lives--;
            }
            
            textLives.text = lives.ToString();
            if (lives > 0) {
                this.transform.position = new Vector3(-12.25f,-3.25f,0);
                if (VolumeManager.isOn) {
                    dieSound.Play();
                }
                died = true;
            } 
            else if (lives <= 0) {
                SceneManager.LoadScene("GameOverMenu");
            }
        }
        if(collectable.transform.tag == "EnemyOrLift"){
            if (SceneManager.GetActiveScene().name != "Tutorial"){
                    lives--;
            }
            textLives.text = lives.ToString();
            if (lives > 0) {
                this.transform.position = new Vector3(-12.25f,-3.25f,0);
                if (VolumeManager.isOn) {
                    dieSound.Play();
                }
                died = true;
            } 
            else if (lives <= 0) {
                SceneManager.LoadScene("GameOverMenu");
            }
        }
        if(collectable.transform.tag == "Finish"){
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
        if(collectable.transform.tag == "Trampoline"){
            pMov.Trampolining();
        }

    }
    
}