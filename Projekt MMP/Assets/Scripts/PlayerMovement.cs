using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float crouchSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] AudioSource jumpSound;
    [SerializeField] private float respawnTimer;
    private float cooldownRespawnTimer;
    
    private Rigidbody2D body;
    private Animator anim;

    private bool onTheGround = true;
    private bool crouched = false;
    private float playerScale = 0.4f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cooldownRespawnTimer = respawnTimer;
    }
    
    private void Update(){

        
        float speed = crouchSpeed;
        if (!crouched) {
            speed = sprintSpeed;
        }

        float horInput = Input.GetAxisRaw("Horizontal");
        anim.SetBool("Run",horInput != 0);
        anim.SetBool("OnTheGround",onTheGround);

        if (Interactables.died) {
            horInput = 0;
            onTheGround = true;
            body.velocity = new Vector2 (0,0);
            cooldownRespawnTimer -= Time.deltaTime;
            if (cooldownRespawnTimer > 0) {
                return;
            }
        }
        Interactables.died = false;
        cooldownRespawnTimer = respawnTimer;
        
        body.velocity = new Vector2 ( horInput * speed, body.velocity.y);

    
        if(Input.GetKey(KeyCode.Space) && onTheGround && !crouched) {
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.C) && onTheGround) {
            anim.SetBool("Crouch",true);
            crouched = true;
            speed = crouchSpeed;
        }
        else if(Input.GetKeyUp(KeyCode.C) && onTheGround) {
            anim.SetBool("Crouch",false);
            crouched = false;
            speed = sprintSpeed; 
        }
        
        if (horInput > 0.01f) {
            transform.localScale = new Vector3(playerScale,playerScale,1);
        }
        else if (horInput < -0.01f) {
            transform.localScale = new Vector3(-playerScale,playerScale,1);
        }

    }

    private void Jump() {
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        anim.SetTrigger("Jump");
        onTheGround = false;
        if (VolumeManager.isOn) {
            jumpSound.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Ground"){
            onTheGround = true;
        }
        if (collision.gameObject.tag == "EnemyOrLift"){
            onTheGround = true;
        }

    }
    
}
