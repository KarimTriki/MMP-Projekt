using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interactables : MonoBehaviour
{
    [SerializeField] private float maxCoins;
    [SerializeField] private float lives;
    private float coins = 0;
    [SerializeField] private Text textCoins;
    [SerializeField] private Text textLives;

    void Start() {
        textCoins.text = coins.ToString()+'/'+maxCoins.ToString();
        textLives.text = lives.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collectable) {
        if(collectable.transform.tag == "Coin"){
            coins++;
            Destroy(collectable.gameObject);
            textCoins.text = coins.ToString()+'/'+maxCoins.ToString();
        }
        if(collectable.transform.tag == "Life"){
            lives++;
            Destroy(collectable.gameObject);
            textLives.text = lives.ToString();
        }
        if(collectable.transform.tag == "Enemy"){
            lives--;
            textLives.text = lives.ToString();
            if (lives > 0) {
                this.transform.position = new Vector3(-12.25f,-3.25f,0);
            } 
            else if (lives <= 0) {
                SceneManager.LoadScene("GameOverMenu");
            }
        }
        if(collectable.transform.tag == "EnemyOrLift" && collectable.transform.position.y > this.transform.position.y){
            lives--;
            textLives.text = lives.ToString();
            if (lives > 0) {
                this.transform.position = new Vector3(-12.25f,-3.25f,0);
            } 
            else if (lives <= 0) {
                SceneManager.LoadScene("GameOverMenu");
            }
        }
    }
    
}