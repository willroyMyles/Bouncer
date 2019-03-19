using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startblockscript : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody target;

    void Start()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.name == "Character")
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
