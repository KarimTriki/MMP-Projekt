using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script to control player movements
public class PlayerMovement : MonoBehaviour
{
    //Walking speed
    [SerializeField] private float sprintSpeed;

    //Crouching speed
    [SerializeField] private float crouchSpeed;

    //Jumping speed
    [SerializeField] private float jumpPower;

    //Jump sound effect
    [SerializeField] AudioSource jumpSound;

    //Trampoline sound effect
    [SerializeField] AudioSource trampolineSound;

    //After the player dies and gets respawned, he cannot move for (respawnTimer) seconds
    [SerializeField] private float respawnTimer;

    //The variable that goes down from (respawnTimer) seconds to 0 seconds and after that the player can move again
    private float cooldownRespawnTimer;
    
    private Rigidbody2D body;
    private Animator anim;

    //Starting position of the player, useful to respawn him later
    public static Vector3 startingPosition;
    private bool onTheGround = true;
    private bool crouched = false;

    //playerScale uses the same sprite scaling ingame to to not mess up the scaling after flipping the player
    public static float playerScale = 0.4f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cooldownRespawnTimer = respawnTimer;
        startingPosition = transform.position;
    }
    
    private void Update(){
        //speed is set by default to sprint speed and if the player is crouched, it's set to crouch speed
        float speed = sprintSpeed;
        if (crouched) {
            speed = crouchSpeed;
        }

        float horInput = Input.GetAxisRaw("Horizontal");
        anim.SetBool("Run",horInput != 0 && !PauseMenu.paused);
        anim.SetBool("OnTheGround",onTheGround);

        //If the player dies, make him unable to move for (respawnTimer) seconds
        if (Interactables.died) {
            horInput = 0;
            onTheGround = true;
            body.velocity = new Vector2 (0,0);
            cooldownRespawnTimer -= Time.deltaTime;
            if (cooldownRespawnTimer > 0) {
                return;
            }
        }

        //After the delay, set died to false and reset the cooldowntimer
        Interactables.died = false;
        cooldownRespawnTimer = respawnTimer;
        
        //Move the player left and right
        body.velocity = new Vector2 ( horInput * speed, body.velocity.y);

        //Jump if the player is on the ground and not crouched
        if(Input.GetKey(KeyCode.Space) && onTheGround && !crouched) {
            Jump();
        }

        //crouch if the player holds the key and is on the ground
        if(Input.GetKeyDown(KeyCode.C) && onTheGround) {
            anim.SetBool("Crouch",true);
            crouched = true;
            speed = crouchSpeed;
        }

        //stand up if the player releases the key
        else if(Input.GetKeyUp(KeyCode.C)) {
            anim.SetBool("Crouch",false);
            crouched = false;
            speed = sprintSpeed; 
        }
        
        //Flip the player to the direction of the movement
        if (horInput > 0 && !PauseMenu.paused) {
            transform.localScale = new Vector3(playerScale,playerScale,1);
        }
        else if (horInput < 0 && !PauseMenu.paused) {
            transform.localScale = new Vector3(-playerScale,playerScale,1);
        }

    }

    private void Jump() {
        //Jump, activate the jumping animation and play the jumping sound effect
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        anim.SetTrigger("Jump");
        onTheGround = false;
        if (VolumeManager.isOn) {
            jumpSound.Play();
        }
    }

    public void Trampolining() {
        //Launch the player in the air, activate the jumping animation and play the trampoline sound effect
        body.velocity = new Vector2(body.velocity.x, jumpPower*1.5f);
        anim.SetTrigger("Jump");
        onTheGround = false;
        if (VolumeManager.isOn) {
            trampolineSound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        //The player is on the ground if he touches an object with certain tags
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "FallingPlatform"){
            onTheGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        //The player is not on the ground if he no longer touches an object with certain tags
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "FallingPlatform"){
            onTheGround = false;
        }
    }
    
}
