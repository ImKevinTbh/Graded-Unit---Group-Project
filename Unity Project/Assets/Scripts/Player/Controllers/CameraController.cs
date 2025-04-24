using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance = null;
    public GameObject p;
    // Start is called before the first frame update
    void Start()
    {
            instance = this;
            p = GameObject.Find("PlayerModel").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.position = new Vector3(p.transform.position.x, p.transform.position.y, p.transform.position.z - 1f);
    }
}
