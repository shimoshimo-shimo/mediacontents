using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowmove : MonoBehaviour
{
    // 変数aをクラスのフィールドとして宣言
    private int a;

    // Start is called before the first frame update
    void Start()
    {
        // 変数aの初期化
        a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("down"))
        {
            a += 1;
        }
        else if (Input.GetKeyDown("up"))
        {
            a -= 1;
        }

        if (a % 3 == 0)
        {
            transform.position = new Vector3(-2.5f, 0.5f, 0);
        }
        else if (a % 3 == 1)
        {
            transform.position = new Vector3(-2.5f, -0.75f, 0);
        }
        else if (a % 3 == 2)
        {
            transform.position = new Vector3(-2.5f, -2f, 0);
        }
    }
}


