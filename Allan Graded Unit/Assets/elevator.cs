using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour
{

    private float i = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (i <= 0)
        {
            gameObject.transform.possition += new vector3(0, 0, 0);
        }
        if (i > 0)
        {
            gameObject.transform.possition -= new vector3(0, 0, 0);
        }
    }
}
