using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    public GameObject dialogue;
    public Text text;
    public Text text2;
    

    // Start is called before the first frame update
    void Start()
    {
        StartScreenLogic();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PlayerPrefs.GetInt("B", 0) == 0)
        {
            dialogue.SetActive(false);
            PlayerPrefs.SetInt("B", 1);
        }
    }

    void StartScreenLogic()
    {
        int b = PlayerPrefs.GetInt("B", 0);

        if (b == 0)
        {
            
            dialogue.SetActive(true);
        }
        else
        {
            dialogue.SetActive(false);
        }
    }
}
