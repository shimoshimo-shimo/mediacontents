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
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "pipo-charachip029_0")
        {
            SceneManager.LoadScene("typing scene");
            
        }
    }   
}
    
