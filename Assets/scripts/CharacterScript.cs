using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public float force = 20;
    Rigidbody rb;
    Color color;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        color = Color.red;
        rend = GetComponent<Renderer>();
        rend.material.color = color;

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

        if (other.CompareTag("startPlatform"))
        {
            Destroy(other.gameObject);
        }

        if (other.CompareTag("contPlatform"))
        {
            FindObjectOfType<GameController>().updateSpeed(0.5f);
            FindObjectOfType<GameController>().UpdateLevel();
            Destroy(other.gameObject);
        }
    }
}
