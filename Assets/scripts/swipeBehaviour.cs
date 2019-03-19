using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector2 direction;
        float speed;

        if (Input.touches[0].phase == TouchPhase.Moved)//Check if Touch has moved.
        {
            direction = Input.touches[0].deltaPosition.normalized;  //Unit Vector of change in position
            speed = Input.touches[0].deltaPosition.magnitude / Input.touches[0].deltaTime; //distance traveled divided by time elapsed
        }

        if (Input.touches.Length > 0)
        {
            Touch touch = Input.touches[0];

            //put your code inside the FixedUpdate() here
            
        }
    }
}
