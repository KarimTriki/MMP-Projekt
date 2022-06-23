using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    private Rigidbody2D body;

    private bool onTheGround = true;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update(){
        float horInput = Input.GetAxisRaw("Horizontal");
        body.velocity = new Vector2 ( horInput * speed, body.velocity.y);
    
        if(Input.GetKey(KeyCode.Space) && onTheGround) {
            Jump();
        }

    }

    private void Jump() {
        body.velocity = new Vector2(body.velocity.x, jumpPower);
        onTheGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Ground"){
            onTheGround = true;
        }

    }
    
}
