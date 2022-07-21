using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject Player;

    public GameObject PlayerScale;

    void OnTriggerEnter2D (Collider2D obj) {
        if (obj.gameObject.tag == "Player") {
            Player.transform.parent = PlayerScale.transform;
        }
    }

    void OnTriggerExit2D (Collider2D obj) {
        if (obj.gameObject.tag == "Player") {
            Player.transform.parent = null;
        }
    }
}
