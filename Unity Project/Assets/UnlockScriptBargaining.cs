using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class UnlockScriptBargaining : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameHandler.instance.Player_Unlock_Dash = true;
        GameHandler.instance.Player_Unlock_RangedAttack = true;
        GameHandler.instance.Player_Unlock_DoubleJump = true;
    }
}
