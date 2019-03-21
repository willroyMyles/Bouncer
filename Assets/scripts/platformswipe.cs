using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformswipe : MonoBehaviour
{
    // Start is called before the first frame update
    private float dragDistance;
    public float speed = 20.0f;
    public float factor = 20.0f;

    void Start()
    {
        dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen
        speed = 20.0f;

    }

    // Update is called once per frame
    void Update()
    {

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
            Vector3 ltouch = Vector3.zero;
            Vector3 ftouch = Vector3.zero;
            if (touch.phase == TouchPhase.Began) //check for the first touch
            { 

            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                ltouch = Camera.main.ScreenToWorldPoint(touch.position);


                Ray raycast = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit raycastHit;
                if (Physics.Raycast(raycast, out raycastHit))
                {

                    Debug.Log(raycastHit.collider.gameObject.name);
                    Debug.Log(raycastHit.collider.transform.position);
                   
                    var go = raycastHit.collider.gameObject;
                    go.transform.Translate(touch.deltaPosition.x / Screen.width * factor, 0.0f, 0.0f);
                    var pos = go.transform.position;
                    pos.x = Mathf.Clamp(go.transform.position.x, -7.23f, 7.15f);
                    go.transform.position = pos;


                }

            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {

             
            }
            else
            {   //It's a tap as the drag distance is less than 20% of the screen height
                Debug.Log("Tap");
            }
        }
    }

}

