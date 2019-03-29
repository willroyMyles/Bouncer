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
    public GameObject character;

    private bool moveCamera = false;
    private float lerpTime;
    private float timeToReachTarget;
    float t;

    float dist;
    Vector3 desPos;
    Vector3 smoPos;
    Vector3 tranPos;

    private void Start()
    {
        target = transform;
    
        cutOffPoint = FindObjectOfType<GameController>().stageHeight;
        Debug.Log(cutOffPoint);
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if (!moveCamera)
        {
            var desiredPosition = target.position + new Vector3(0.0f, -stepSpeed, 0.0f);
            //Vector3 desiredPosition = target.position + offset;
            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothPosition;
        }
        else
        {
            t += Time.deltaTime / timeToReachTarget;
            transform.position = Vector3.Lerp(tranPos, desPos,t);
            if (lerpTime + timeToReachTarget <= Time.time)
            {
                moveCamera = false;
                FindObjectOfType<GameController>().freezeCharacter(false);
            }
        }

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
    public void moveCameToCharacter()
    {
        //stop character to move camera
        lerpTime = Time.time;
        timeToReachTarget = 1.75f;
        dist = Vector3.Distance(character.transform.position, transform.position);
        var distance = character.transform.position.y - transform.position.y;
        Debug.Log(distance + "  "+ dist);
        float yOffset = -7.0f;
        tranPos = transform.position;
        desPos = character.transform.position + new Vector3(0.0f, + yOffset, -10.0f);
        moveCamera = true;
    }
}
