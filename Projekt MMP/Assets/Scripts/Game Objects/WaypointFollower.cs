using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float timerTransition = 0.5f;
    private float cooldownTimer;
    private int currentIndex = 0;
    [SerializeField] private float speed = 2f;

    [Header("Ick for Translation, Untick for Rotation")]
    [SerializeField] private bool translation = true;

    void Start() {
        cooldownTimer = timerTransition;
    }
    void Update()
    {
        if (translation) {
            if (Vector3.Distance(waypoints[currentIndex].transform.position, transform.position) < 0.1f) {
                cooldownTimer -= Time.deltaTime;
                if (cooldownTimer > 0) {
                    return;
                }
                cooldownTimer = timerTransition;
                transform.position = waypoints[currentIndex].transform.position;
                currentIndex++;
                if (currentIndex >= waypoints.Length){
                    currentIndex = 0;
                }        
            }
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentIndex].transform.position, Time.deltaTime*speed);
        }
        else {
            transform.RotateAround(waypoints[currentIndex].transform.position, new Vector3(0,0,1), speed * Time.deltaTime);
        }
    }
}
