using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class statasManager : MonoBehaviour
{

    public static class GlobalVariables
    {
        public static int HP = 0;
        
    }



    // Start is called before the first frame update
    void Start()
    {
        GlobalVariables. HP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
