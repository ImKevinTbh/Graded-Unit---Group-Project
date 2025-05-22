using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockScriptDenial : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameHandler.instance.Player_Unlock_RangedAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
