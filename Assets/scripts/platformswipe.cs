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
        Vector2 direction;
        float speed;

        Vector3 fp = new Vector3();
        Vector3 lp = new Vector3();



#if UNITY_EDITOR
        var list = InputHelper.GetTouches();
#else
        var list= Input.touches;
#endif

        foreach (Touch touch in list)
        {
            Vector3 touchPosition;
            Vector3 ltouch = Vector3.zero;
            Vector3 ftouch = Vector3.zero;
            if (touch.phase == TouchPhase.Began) //check for the first touch
            { 
            //touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, transform.position.y, 0.0f));

            Debug.Log("touch begin");
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                ltouch = Camera.main.ScreenToWorldPoint(touch.position);
                if (Physics.Raycast(ltouch, Camera.main.transform.forward))
                {


                    Debug.Log("touch moved  " );

                    transform.Translate(touch.deltaPosition.x / Screen.width * factor, 0.0f, 0.0f);
                    var pos = transform.position;
                    pos.x = Mathf.Clamp(transform.position.x, -7.23f, 7.15f);
                    transform.position = pos;
          

                    //touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, transform.position.y, 0.0f));
                    //transform.position = Vector3.Lerp(transform.position, new Vector3(touchPosition.x, transform.position.y, 0.0f), Time.deltaTime * 5000f);

                }


                //if ((lp.x > fp.x))  //If the movement was to the right)
                //{   //Right swipe
                //    Debug.Log("Right Swipe");
                //    //this.gameObject.GetComponent<Rigidbody>().MovePosition(new Vector3(lp.x, 0, 0));
                //    Vector3 pos = this.gameObject.transform.position;
                //    pos = pos + new Vector3(lp.x, 0, 0);
                //    this.gameObject.transform.Translate(pos * Time.deltaTime);
                //}
                //else
                //{   //Left swipe
                //    Debug.Log("Left Swipe");
                //    //this.gameObject.GetComponent<Rigidbody>().MovePosition(new Vector3(lp.x, 0, 0));
                //    Vector3 pos = this.gameObject.transform.position;
                //    pos = pos + new Vector3(lp.x, 0, 0);
                //    this.gameObject.transform.Translate(pos * Time.deltaTime);
                //}
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                Debug.Log("touch ended   " + lp);

                //lp = touch.position;  //last touch position. Ommitted if you use list

                ////Check if drag distance is greater than 20% of the screen height
                //if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                //{//It's a drag
                ////check if the drag is vertical or horizontal
                //if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                //{   //If the horizontal movement is greater than the vertical movement...

                //}
                //else
                //{   //the vertical movement is greater than the horizontal movement
                //    if (lp.y > fp.y)  //If the movement was up
                //    {   //Up swipe
                //        Debug.Log("Up Swipe");
                //    }
                //    else
                //    {   //Down swipe
                //        Debug.Log("Down Swipe");
                //    }
                //}
            }
            else
            {   //It's a tap as the drag distance is less than 20% of the screen height
                Debug.Log("Tap");
            }
        }
    }

}

