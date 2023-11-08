using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Inbattle: MonoBehaviour
{

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene("typing scene");//some_senseiシーンをロードする
            }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "pipo-charachip029_0")
        {
            SceneManager.LoadScene("typing scene");
        }
    }   
}
    
