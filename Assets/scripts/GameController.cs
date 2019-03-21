using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public float level;
    public Collider col;
    public GameObject start;
    public GameObject prefab;
    public GameObject finish;
    public float distance = 2.0f;
    public float stageHeight;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(stageHeight);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Awake()
    {
        stageHeight = level * 2 + 10;

        col = GetComponent<Collider>();

        Instantiate(start, col.transform.position, Quaternion.identity);
        col.transform.position = col.transform.position + new Vector3(0, -distance, 0);

        for (int i = 0; i < level*2; i++)
        {
            float x = Random.Range(-7.23f, 7.15f);
            Vector3 vec = new Vector3( x, col.transform.position.y, 0.0f);
            Instantiate(prefab, vec, Quaternion.identity);
            col.transform.position = col.transform.position + new Vector3(0, -distance, 0);

        }
        Instantiate(finish, col.transform.position, Quaternion.identity);

    }

    public void restartCurrentScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
