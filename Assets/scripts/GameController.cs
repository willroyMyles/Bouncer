using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    int level = 1;
    public Collider col;
    public GameObject start;
    public GameObject prefab;
    public GameObject prefabcol;
    public GameObject finish;
    public float distance = 2.0f;
    public float stageHeight;

    private int levelModifier = 5;
    private int score = -1;
    public TMPro.TextMeshProUGUI tmp;


    public void loadGame()
    {
        Initiate.Fade("SampleScene", Color.blue, 2.0f);
        restartCurrentScene();
    }

    private void Awake()
    {
        stageHeight = level * levelModifier + 15;

        StartGame();
        UpdatePoints();
    }

    public void restartCurrentScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void StartGame()
    {
        col = GetComponent<Collider>();
       

        if(level == 1) Instantiate(start, col.transform.position, Quaternion.identity);
        col.transform.position = col.transform.position + new Vector3(0, -distance, 0);

        for (int i = 0; i < level * levelModifier; i++)
        {
            GameObject go = prefab;
            if(level > 1)
            {
                if (Random.Range(1, 2) % 2 == 0) go = prefab;
                else go = prefabcol;
            }
            float x = Random.Range(-7.23f, 7.15f);
            Vector3 vec = new Vector3(x, col.transform.position.y, 0.0f);
            Instantiate(go, vec, Quaternion.identity);
            col.transform.position = col.transform.position + new Vector3(0, -distance, 0);

        }
        col.transform.position = col.transform.position + new Vector3(0, -distance, 0);
        Instantiate(finish, col.transform.position, Quaternion.identity);
    }

    public void UpdateLevel()
    {
        level++;
        DestroyAllPlatforms();
        StartGame();
    }

    public void DestroyAllPlatforms()
    {
        // TODO put small animation
        var list = GameObject.FindGameObjectsWithTag("platform");
        foreach( var obj in list)
        {
            Destroy(obj, 1);
        }
    }

    public void UpdatePoints()
    {
        score++;
        tmp.text = score.ToString();
    }

    public void updateSpeed()
    {
        FindObjectOfType<CameraFollow>().updateCameraSpeed();
    }

    public void updateSpeed(float speed)
    {
        FindObjectOfType<CameraFollow>().updateCameraSpeed(speed);
    }

    public void endGame()
    {
        Initiate.Fade("main_menu", Color.blue, 2.0f);

    }

    public void changeCameraPerspective()
    {
        if (Camera.main.orthographic) Camera.main.orthographic = false;
        else Camera.main.orthographic = true;
    }
}
