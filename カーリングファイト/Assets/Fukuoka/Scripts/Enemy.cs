using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    GameObject mGameObjectSwipe = null;

    Rigidbody2D rig2D;

    bool bUse = false;

    // Use this for initialization
    void Awake()
    {
        mGameObjectSwipe = GameObject.Find("Swaipe");
        rig2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        //if (!bUse)
        //{
        //    if (mGameObjectSwipe.GetComponent<Swipe>().VecPower.x > 0)
        //    {
        //        rig2D.velocity = new Vector2(mGameObjectSwipe.GetComponent<Swipe>().VecPower.x * 0.01f,
        //                mGameObjectSwipe.GetComponent<Swipe>().VecPower.y * 0.01f);
        //        bUse = true;
        //    }
        //}

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
