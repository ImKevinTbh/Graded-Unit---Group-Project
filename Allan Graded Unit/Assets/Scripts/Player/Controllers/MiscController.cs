//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MiscController : MonoBehaviour
//{

//    public Events Events = new Events();

//    void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.gameObject.tag == "door")
//        {
//            Events.OnEnter(null);

//            Debug.Log("player entered room, door should close now");
//        }
//        else
//        {
//            Debug.Log("not the player, door should stay closed");
//        }
//    }

//}
