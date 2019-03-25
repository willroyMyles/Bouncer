using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

     Transform target;
     float smoothSpeed = 0.02f;
     Vector3 offset = Vector3.zero;
     public float stepSpeed = 0.6f;
     float cutOffPoint;

    private void Start()
    {
        target = transform;

    
        cutOffPoint = FindObjectOfType<GameController>().stageHeight;
        Debug.Log(cutOffPoint);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var desiredPosition = target.position + new Vector3(0.0f, -stepSpeed, 0.0f);
        //Vector3 desiredPosition = target.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition;

        //if (transform.position.y <= -cutOffPoint) stepSpeed = 0.0f;
    }

    public void updateCameraSpeed()
    {
        stepSpeed += .2f;
        if (stepSpeed >= 2) stepSpeed = 2.0f;
    }
    public void updateCameraSpeed(float added)
    {
        stepSpeed += added;
        if (stepSpeed >= 2) stepSpeed = 2.0f;
    }
}
