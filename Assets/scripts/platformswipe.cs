using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class platformswipe : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    // Start is called before the first frame update
    private float dragDistance;
    public float factor = 20.0f;

    Vector3 ltouch = Vector3.zero;
    Vector3 ftouch = Vector3.zero;

    Touch firstTouch;
    Touch lastTouch;
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
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                ltouch = Camera.main.ScreenToWorldPoint(touch.deltaPosition);


                Ray raycast = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit raycastHit;
                if (Physics.Raycast(raycast, out raycastHit))
                {

                    var go = raycastHit.collider.gameObject;
                    go.transform.Translate(touch.deltaPosition.x / Screen.width * factor, 0.0f, 0.0f);
                    var pos = go.transform.position;
                    pos.x = Mathf.Clamp(go.transform.position.x, -7.23f, 7.15f);
                    go.transform.position = pos;

                }

            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lastTouch = touch;
                Debug.Log(firstTouch);
                Debug.Log(lastTouch);

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
                            Debug.Log("down");
                        }
                        else
                        {
                            //swiped up
                            Debug.Log("up");
                            FindObjectOfType<GameController>().updateSpeed();
                        }
                    }
                }

                //if (Mathf.Abs(ltouch.x - ftouch.x) > dragDistance || Mathf.Abs(ltouch.y - ftouch.y) > dragDistance)
                //if (Mathf.Abs(ltouch.x + ftouch.x) > Mathf.Abs(ltouch.y + ftouch.y)) // horizontal drag
                //{
                //    Debug.Log(" ltouch " + ltouch);
                //    Debug.Log(" ftouch " + ftouch);

                //    Debug.Log(Mathf.Abs(ltouch.x - ftouch.x) + "touch x");
                //    Debug.Log(Mathf.Abs(ltouch.y - ftouch.y) + "touch y");
                //}
                //else // vertical drag
                //{
                //    Debug.Log(" ltouch " + ltouch);
                //    Debug.Log(" ftouch " + ftouch);

                //    if (ltouch.y < ftouch.y) // if upwards swipe
                //        FindObjectOfType<GameController>().updateSpeed();
                //}
            }
            else
            {   //It's a tap as the drag distance is less than 20% of the screen height
                Debug.Log("Tap");
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("drag start");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("drag end");
    }
}

