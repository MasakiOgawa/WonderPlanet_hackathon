using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCollision : MonoBehaviour {
	//const float standardRadius = 46.875f;
	const float shortRange = 2.0f;
	const float middleRange = 1.5f;
	const float longRange = 1.0f;

	[SerializeField]
	private PlayerManager pm;
	private EnemyManager em;

	void OnTriggerEnter2D(Collider2D col)
	{
		Vector2 velocity = col.gameObject.GetComponent<Rigidbody2D>().velocity;
		bool isActed;
		Vector2 pos;
		pos.x = transform.position.x;
		pos.y = transform.position.y;
		float standardRadius = GetComponent<CircleCollider2D>().radius / 4;
		Vector2 otherPos = new Vector2(col.gameObject.transform.position.x, col.gameObject.transform.position.y);
		if(otherPos.x < 0 )
		{
			otherPos.x *= -1;
		}
		if (otherPos.y < 0)
		{
			otherPos.y *= -1;
		}
		float otherRadius = col.GetComponent<CircleCollider2D>().radius;
		float distance = ((otherPos - pos).magnitude) - otherRadius;

		Debug.Log("Hit:");
		Debug.Log(standardRadius);
		Debug.Log(otherPos.x);
		Debug.Log(otherPos.y);
		Debug.Log(distance);
		Debug.Log(otherRadius);
		Debug.Log(velocity.x);
		Debug.Log(velocity.y);

		if (col.gameObject.tag == "Player")
		{	
			isActed = col.gameObject.GetComponent<PlayerStatus>().IsActed;

			// 行動が終わっていて、速度が0の場合
			if (!isActed && velocity.x <= 0 )
			{
				int playerAttackQty = col.gameObject.GetComponent<PlayerStatus>().Attack;						

				// サークルの中心点からの距離によるダメージ処理
				//	>>中心～短距離
				//	>>短距離～中距離
				//	>>中距離～長距離
				//	>>範囲外			→　オブジェクトを破棄する
				if( distance <= standardRadius ) 
				{
					Debug.Log("short");
					em.Life -= (int)(playerAttackQty * shortRange);
				}
				else if( standardRadius < distance && distance <= standardRadius * 2 )
				{
					Debug.Log("middle");
					em.Life -= (int)(playerAttackQty * middleRange);
				}
				else if (standardRadius * 2 < distance && distance <= standardRadius * 3 )
				{
					Debug.Log("long");
					em.Life -= (int)(playerAttackQty * longRange);
				}
				else if(standardRadius * 3 < distance )
				{
					Debug.Log("範囲外");
					//Destroy(col);
				}
				col.gameObject.GetComponent<PlayerStatus>().IsActed = true;
			}

		}

		if (col.gameObject.tag == "EnemyUnit")
		{
			isActed = col.gameObject.GetComponent<EnemyStatus>().IsActed;

			// 行動が終わっていて、速度が0の場合
			if (!isActed && velocity.x <= 0 )
			{
				int enemyAttackQty = col.gameObject.GetComponent<PlayerStatus>().Attack;

				// サークルの中心点からの距離によるダメージ処理
				//	>>中心～短距離
				//	>>短距離～中距離
				//	>>中距離～長距離
				//	>>範囲外			→　オブジェクトを破棄する
				if (distance <= standardRadius)
				{
					Debug.Log("short");
					pm.Life -= (int)(enemyAttackQty * shortRange);
				}
				else if (standardRadius < distance && distance <= standardRadius * 2)
				{
					Debug.Log("middle");
					pm.Life -= (int)(enemyAttackQty * middleRange);
				}
				else if (standardRadius * 2 < distance && distance <= standardRadius * 3)
				{
					Debug.Log("long");
					pm.Life -= (int)(enemyAttackQty * longRange);
				}
				else if(standardRadius * 3 < distance )
				{
					Debug.Log("範囲外");
					//Destroy(col);
				}
				col.gameObject.GetComponent<EnemyStatus>().IsActed = true;
			}
		}
			
	}


	//// Use this for initialization
	//void Start () {

	//}

	//// Update is called once per frame
	//void Update () {

	//}
}

		//if (col.gameObject.tag == "Player")
		//{
		//	Debug.Log("プレイヤーだお");

		//	//int playerAttackQty = col.gameObject< ;
		//	//float distance = ((otherPos - pos).magnitude) - otherRadius;

		//	// サークルの中心点からの距離によるダメージ処理
		//	//	>>中心～短距離
		//	//	>>短距離～中距離
		//	//	>>中距離～長距離
		//	//	>>範囲外			→　オブジェクトを破棄する
		//	if (distance <= standardRadius)
		//	{
		//		Debug.Log("short");
		//		//em.Life -= playerAttackQty * shortRange;
		//	}
		//	else if (standardRadius<distance && distance <= standardRadius* 2)
		//	{
		//		Debug.Log("middle");
		//		//em.Life -= playerAttackQty * middleRange;
		//	}
		//	else if (standardRadius* 2 < distance && distance <= standardRadius* 3)
		//	{
		//		Debug.Log("long");
		//		//em.Life -= playerAttackQty * longRange;
		//	}
		//	else //if(standardRadius * 3 < distance )
		//	{
		//		Debug.Log("範囲外");
		//		//Destroy(col);
		//	}
		//}