﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class platformswipe : MonoBehaviour
{
    // Start is called before the first frame update
    private float dragDistance;
    public float factor = 20.0f;

    Vector3 ltouch = Vector3.zero;
    Vector3 ftouch = Vector3.zero;

    Touch firstTouch;
    Touch lastTouch;

    GameObject currentGameObject;
    bool hasGameObject = false;
    void Start()
    {
        dragDistance = Screen.height * 5 / 100; //dragDistance is 15% height of the screen

    }



    void FixedUpdate()
    {


#if UNITY_EDITOR
        var list = InputHelper.GetTouches();
#else
        var list= Input.touches;
#endif

        foreach (Touch touch in list)
        { 

        if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                firstTouch = touch;
                ftouch = Camera.main.ScreenToWorldPoint(touch.position);

                Ray raycast = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit raycastHit;
                if (Physics.Raycast(raycast, out raycastHit))
                {
                    if(raycastHit.collider.CompareTag("platform"))  currentGameObject = raycastHit.collider.gameObject;
                    hasGameObject = true;
                }

            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                //ltouch = Camera.main.ScreenToWorldPoint(touch.deltaPosition);


                //Ray raycast = Camera.main.ScreenPointToRay(touch.position);
                //RaycastHit raycastHit;
                //if (Physics.Raycast(raycast, out raycastHit))
                //{

                //    var go = raycastHit.collider.gameObject;
                //    go.transform.Translate(touch.deltaPosition.x / Screen.width * factor, 0.0f, 0.0f);
                //    var pos = go.transform.position;
                //    pos.x = Mathf.Clamp(go.transform.position.x, -7.23f, 7.15f);
                //    go.transform.position = pos;

                //}
                if (hasGameObject)
                {
                    currentGameObject.transform.Translate(touch.deltaPosition.x / Screen.width * factor, 0.0f, 0.0f);
                    var pos = currentGameObject.transform.position;
                    pos.x = Mathf.Clamp(currentGameObject.transform.position.x, -7.23f, 7.15f);
                    currentGameObject.transform.position = pos;
                }

            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lastTouch = touch;

                hasGameObject = false;

                if(Mathf.Abs(firstTouch.position.x - lastTouch.position.x) > dragDistance ||
                    Mathf.Abs(firstTouch.position.y - lastTouch.position.y) > dragDistance)
                {
                    // if drag is large enough
                    if(Mathf.Abs(firstTouch.position.x - lastTouch.position.x) > Mathf.Abs(firstTouch.position.y - lastTouch.position.y))
                    {
                        // horizontal movement
                    }
                    else
                    {
                        //vertical movement
                        if(firstTouch.position.y > lastTouch.position.y)
                        {
                            // swiped down
                        }
                        else
                        {
                            //swiped up
                           // FindObjectOfType<GameController>().updateSpeed();
                        }
                    }
                }

            }
            else
            {   //It's a tap as the drag distance is less than 20% of the screen height
                Debug.Log("Tap");
            }
        }
    }


}

