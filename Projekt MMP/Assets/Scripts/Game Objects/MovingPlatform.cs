using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject Player;

    public GameObject PlayerScale;

    //On Collision, make the player a child of PlayerScale which is a child of the falling Platform
    //Player scale is used to revert the scaling done on the parent object
    void OnTriggerEnter2D (Collider2D obj) {
        if (obj.gameObject.tag == "Player") {
            Player.transform.parent = PlayerScale.transform;
        }
    }

    //Reset when player jumps out
    void OnTriggerExit2D (Collider2D obj) {
        if (obj.gameObject.tag == "Player") {
            Player.transform.parent = null;
        }
    }
}
