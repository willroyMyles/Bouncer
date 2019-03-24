using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadGame()
    {
        Initiate.Fade("SampleScene", Color.blue, 2.0f);
    }

    public void loadMainMenu()
    {
        Initiate.Fade("main_menu", Color.blue, 2.0f);
    }
}
