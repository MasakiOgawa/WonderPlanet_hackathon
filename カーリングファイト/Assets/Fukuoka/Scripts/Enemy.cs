﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    GameObject mGameObjectSwipe = null;

    Rigidbody2D rig2D;

    public bool bUse = false;

    Vector2 move;

    // Use this for initialization
    void Awake()
    {
        move = GetComponent<PlayerStatus>().Move;
        move = new Vector2(0, 0);

        mGameObjectSwipe = GameObject.Find("Swaipe");
        rig2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!bUse)
        {
            if (mGameObjectSwipe.GetComponent<Swipe>().VecPower.x > 0)
            {
                move = new Vector2(mGameObjectSwipe.GetComponent<Swipe>().VecPower.x * 0.05f,
                        mGameObjectSwipe.GetComponent<Swipe>().VecPower.y * 0.05f);
                bUse = true;
            }
        }

        rig2D.velocity = new Vector2(move.x, move.y);


        if (move.x > 0.1f)
        {
            move.x *= 0.99f;
        }
        else if (move.x <= 0.1f)
        {
            move.x = 0;
        }

        if (move.y > 0.1f)
        {
            move.y *= 0.99f;
        }
        else if (move.y <= 0.1f)
        {
            move.y = 0;
        }

        GetComponent<PlayerStatus>().Move = move;

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity += rig2D.velocity;
            rig2D.velocity -= rig2D.velocity * 0.001f;
        }

        if (collision.gameObject.tag == "EnemyUnit")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity += rig2D.velocity * 1.5f;
        }
    }
}
