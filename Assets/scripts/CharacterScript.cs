using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public float force = 20;
    Rigidbody rb;
    Color color;
    Renderer rend;

    private bool freezeCharacter = false;
    private Vector3 characterPos;

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
        if (freezeCharacter)
        {
          //  rb.position = characterPos;
        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            rb.AddForce(0, force, 0);
        }

        if (collision.gameObject.tag == "enemy")
        {
            FindObjectOfType<GameController>().endGame();
        }

        if (collision.gameObject.CompareTag("contPlatform"))
        {
            rb.AddForce(0, force, 0);
            Destroy(collision.gameObject);
            FindObjectOfType<GameController>().updateSpeed(0.2f);
            FindObjectOfType<GameController>().UpdateLevel();
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

    }

    public void freeze()
    {
        characterPos = rb.position;
        freezeCharacter = true;
    }

    public void unFreeze()
    {
        freezeCharacter = false;
    }

    public void addsForce(int fo)
    {
        rb.AddForce(0, fo, 0);
    }
}
