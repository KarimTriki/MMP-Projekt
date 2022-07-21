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
        xPos = this.transform.position.x;
        yPos = this.transform.position.y;
    }

    void OnCollisionEnter2D (Collision2D obj) {
        if (obj.gameObject.tag == "Player") {
            Invoke("Drop",dropCountdown);
        }
    }

    void OnCollisionExit2D (Collision2D obj) {
        if (obj.gameObject.tag == "Player") {
            Invoke("Reset",resetCountdown);
        }
    }

    void Drop() {
        body.isKinematic = false;
    }

    void Reset() {
        body.isKinematic = true;
        transform.position = new Vector3(xPos,yPos,0);
    }
}
