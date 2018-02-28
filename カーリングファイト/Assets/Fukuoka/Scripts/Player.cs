using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Marvest.Sounds;

public class Player : MonoBehaviour {

    [SerializeField]
     GameObject mGameObjectSwipe = null;

    Rigidbody2D rig2D;

    Vector2 move;

    public bool bUse = false;

    [SerializeField]
    private Sprite Sp1;

    [SerializeField]
    private Sprite Sp2;

    [SerializeField]
    private Sprite Sp3;

    [SerializeField]
    private Sprite Sp4;

    [SerializeField]
    private SpriteRenderer SpRen;

	[SerializeField]
	private TurnManager tm;

    [SerializeField]
    GameObject Sound = null;

    // Use this for initialization
    void Awake () {

        move = GetComponent<PlayerStatus>().Move;
        move = new Vector2(0, 0);

		GameObject gb = GameObject.Find("TurnManager");
		tm = gb.GetComponent<TurnManager>();
		mGameObjectSwipe = GameObject.Find("Swaipe");
        rig2D = GetComponent<Rigidbody2D>();

        Sound = GameObject.Find("SoundEffect");
    }
	
	// Update is called once per frame
	void Update () {

        if (!bUse)
        {
            if (mGameObjectSwipe.GetComponent<Swipe>().VecPower.x > 0)
            {
                move = new Vector2(mGameObjectSwipe.GetComponent<Swipe>().VecPower.x * 0.05f,
                        mGameObjectSwipe.GetComponent<Swipe>().VecPower.y * 0.05f);
                bUse = true;
            }
        }

		if ( bUse && move.x <= 0 && move.y <= 0)
		{
			if (!tm.NowTurn)
			{
				tm.NowTurn = true;
			}
		}

		rig2D.velocity = new Vector2(move.x, move.y);

        Debug.Log("moveX" + GetComponent<PlayerStatus>().Move.x);
        Debug.Log("moveY" + GetComponent<PlayerStatus>().Move.y);

        if (move.x > 0.1f || move.x < -0.1f)
        {
            Sound.GetComponent<SoundEffect>().IceSlideSe();
            move.x *= 0.99f;
        }
        else if (move.x <= 0.1f && move.x >= -0.1f)
        {
            move.x = 0;
        }

        if (move.y > 0.1f || move.y < -0.1f)
        {
            move.y *= 0.99f;
        }
        else if (move.y <= 0.1f && move.y >= -0.1f)
        {
            move.y = 0;
        }

        GetComponent<PlayerStatus>().Move = move;

    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity += rig2D.velocity * 1.5f;
            rig2D.velocity -= rig2D.velocity * 0.001f;
        }

        if (collision.gameObject.tag == "EnemyUnit")
        {
            Sound.GetComponent<SoundEffect>().PlayStoneHitSe();
            collision.gameObject.GetComponent<Rigidbody2D>().velocity += rig2D.velocity * 1.5f;
            rig2D.velocity -= rig2D.velocity * 0.001f;
        }
    }

    public void SetCharaType(int num)
    {
        switch (num)
        {
            case 1:
                SpRen.sprite = Sp1;
                break;
            case 2:
                SpRen.sprite = Sp2;
                break;
            case 3:
                SpRen.sprite = Sp3;
                break;
            case 4:
                SpRen.sprite = Sp4;
                break;
        }
    }
}
