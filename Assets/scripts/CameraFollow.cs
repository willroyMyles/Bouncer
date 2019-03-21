using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

     Transform target;
     float smoothSpeed = 0.02f;
     Vector3 offset = Vector3.zero;
     float stepSpeed = 0.1f;
     float cutOffPoint;

    private void Start()
    {
        target = transform;

        var go = GameObject.FindObjectOfType<GameController>();
        cutOffPoint = go.stageHeight;
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
}
