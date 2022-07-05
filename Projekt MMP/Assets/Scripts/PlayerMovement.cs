using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    private Rigidbody2D body;
    private Animator anim;

    private bool onTheGround = true;
    private bool crouched = false;
    private float playerScale = 0.4f;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update(){
        float horInput = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2 ( horInput * speed, body.velocity.y);
    
        if(Input.GetKey(KeyCode.Space) && onTheGround && !crouched) {
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.C) && onTheGround) {
            anim.SetBool("Crouch",true);
            crouched = true;
            speed = speed/5;
        }
        else if(Input.GetKeyUp(KeyCode.C) && onTheGround) {
            anim.SetBool("Crouch",false);
            crouched = false;
            speed = speed * 5;
        }
        
        if (horInput > 0.01f) {
            transform.localScale = new Vector3(playerScale,playerScale,1);
        }
        else if (horInput < -0.01f) {
            transform.localScale = new Vector3(-playerScale,playerScale,1);
        }

        anim.SetBool("Run",horInput != 0);
        anim.SetBool("OnTheGround",onTheGround);
    }

    private void Jump() {
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        anim.SetTrigger("Jump");
        onTheGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Ground"){
            onTheGround = true;
        }

    }
    
}
