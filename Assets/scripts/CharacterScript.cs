using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public float force = 20;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            rb.AddForce(0, force, 0);
            //rb.AddExplosionForce(force, Vector3.up, 3);
        }
        if (collision.gameObject.tag == "contPlatform")
        {
            FindObjectOfType<GameController>().UpdateLevel();
        }

        if(collision.gameObject.tag == "MainCamera")
        {
            FindObjectOfType<GameController>().endGame();
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("platform"))
        {
            FindObjectOfType<GameController>().UpdatePoints();
            other.enabled = false;
        }

        if(other.CompareTag("MainCamera"))
        {
            FindObjectOfType<GameController>().endGame();
        }

    }
}
