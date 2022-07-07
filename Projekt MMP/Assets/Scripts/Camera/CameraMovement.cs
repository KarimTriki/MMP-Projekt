using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //This script is for the camera to follow our player

    // The target that will be followed by the camera
    [SerializeField] private Transform target;

    //Make use of the .Lerp() function to make the camera movement smooth
    [SerializeField] private float lerpFactor;

    // We would love to have a camera that's limited on the bottom Y, Top Y and Left X
    // The only unlimited value is the Right X
    [SerializeField] private float limitXAxis = -7;
    [SerializeField] private float limitYAxisDown = -1;
    [SerializeField] private float limitYAxisUp = 4;


    // Update is called once per frame and executes FollowTarget();
    private void Update()
    {
        FollowTarget();
    }

    void FollowTarget() {

        //Case if the target Y position exceeds the Upper Limit Y, se the camera's Y position to that limit
        if (target.position.y >= limitYAxisUp) {
            Vector3 targetPosition = new Vector3(Mathf.Max(limitXAxis,target.position.x), limitYAxisUp, transform.position.z);
            Vector3 smoothTransitionPosition = Vector3.Lerp(transform.position, targetPosition, lerpFactor*Time.fixedDeltaTime);
            transform.position = smoothTransitionPosition;
        }

        //Else just compare the target X Y positions to the Lower X Y limits and feed the maximum of those to the camera's position
        else {
            Vector3 targetPosition = new Vector3(Mathf.Max(limitXAxis,target.position.x), Mathf.Max(limitYAxisDown,target.position.y), transform.position.z);
            Vector3 smoothTransitionPosition = Vector3.Lerp(transform.position, targetPosition, lerpFactor*Time.fixedDeltaTime);
            transform.position = smoothTransitionPosition;
        }
    }
}
