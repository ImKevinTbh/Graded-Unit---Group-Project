using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstance : EnemyCore
{
    public static EnemyInstance Instance = null;
    void Awake()
    {
        Instance = this;
    }
}
