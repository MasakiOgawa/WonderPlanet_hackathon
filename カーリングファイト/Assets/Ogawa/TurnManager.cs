using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public bool NowTurn;           // 現在のターン false プレイヤー true エネミー

    // Use this for initialization
    void Start()
    {
        NowTurn = false;    // プレイヤーターン
    }

    // Update is called once per frame
    void Update()
    {

    }
}
