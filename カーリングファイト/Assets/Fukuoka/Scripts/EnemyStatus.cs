using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour {

    public int Attack
    {
        get;
        set;
    }

    public bool IsActed
    {
        get;
        set;
    }

    public Vector2 Move
    {
        get;
        set;
    }
}
