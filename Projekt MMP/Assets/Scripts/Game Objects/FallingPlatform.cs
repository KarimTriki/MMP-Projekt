using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float dropCountdown = 0.5f;
    [SerializeField] private float resetCountdown = 3f;
    private float xPos;
    private float yPos;
    Rigidbody2D body;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //Keep track of the original X and Y positions of the falling Platform
        xPos = this.transform.position.x;
        yPos = this.transform.position.y;
    }

    //On collision, drop
    void OnCollisionEnter2D (Collision2D obj) {
        if (obj.gameObject.tag == "Player") {
            Invoke("Drop",dropCountdown);
        }
    }

    //Reset, after the player jumps out
    void OnCollisionExit2D (Collision2D obj) {
        if (obj.gameObject.tag == "Player") {
            Invoke("Reset",resetCountdown);
        }
    }

    //RigidBody from Kinematic to Dynamic -> Falls with gravity
    void Drop() {
        body.isKinematic = false;
    }

    //Reset to original X and Y and change to kinematic
    void Reset() {
        body.isKinematic = true;
        transform.position = new Vector3(xPos,yPos,0);
    }
}
