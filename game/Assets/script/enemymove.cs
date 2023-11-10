using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;

        Vector3 pos = myTransform.position;
        pos.x += 5;
        //StartCoroutine(Wait());
        pos.x -= 5;

        myTransform.position = pos;
    }
}
