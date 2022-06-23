using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 zAxisOffset;
    [SerializeField] private float lerpFactor;

    private float limitXAxis = -7;
    private float limitYAxis = -1;


    // Update is called once per frame
    private void Update()
    {
        FollowTarget();
    }

    void FollowTarget() {
        if (target.position.x > -7 && target.position.y > -1) {
            Vector3 targetPosition = target.position + zAxisOffset;
            Vector3 smoothTransitionPosition = Vector3.Lerp(transform.position, targetPosition, lerpFactor*Time.fixedDeltaTime);
            transform.position = smoothTransitionPosition;
        }
        else if (target.position.x < limitXAxis && target.position.y < limitYAxis){
            Vector3 endXYAxisPosition = new Vector3(limitXAxis, limitYAxis, target.position.z) + zAxisOffset;
            Vector3 smoothTransitionPosition = Vector3.Lerp(transform.position, endXYAxisPosition, lerpFactor*Time.fixedDeltaTime);
            transform.position =  smoothTransitionPosition;
        }
        else if (target.position.x < limitXAxis){
            Vector3 endXAxisPosition = new Vector3(limitXAxis, target.position.y, target.position.z) + zAxisOffset;
            Vector3 smoothTransitionPosition = Vector3.Lerp(transform.position, endXAxisPosition, lerpFactor*Time.fixedDeltaTime);
            transform.position =  smoothTransitionPosition;
        }
        else if (target.position.y < limitYAxis){
            Vector3 endYAxisPosition = new Vector3(target.position.x, limitYAxis, target.position.z) + zAxisOffset;
            Vector3 smoothTransitionPosition = Vector3.Lerp(transform.position, endYAxisPosition, lerpFactor*Time.fixedDeltaTime);
            transform.position =  smoothTransitionPosition;
        }
    }
}
