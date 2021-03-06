﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCollision : MonoBehaviour {
	//const float standardRadius = 46.875f;
	const float shortRange = 2.0f;
	const float middleRange = 1.5f;
	const float longRange = 1.0f;

	private bool isChangedTurn;
	private int changeCount;

	[SerializeField]
	private PlayerManager pm;

	[SerializeField]
	private EnemyManager em;

	[SerializeField]
	private TurnManager tm;

	[SerializeField]
	private GameObject damageUI;

	void Start()
	{
		isChangedTurn = false;
		changeCount = 5;
	}

	void Update()
	{
		if(isChangedTurn)
		{
			changeCount--;
		}

		if(changeCount == 0)
		{
			// チェンジフラグ
			isChangedTurn = false;
			changeCount = 5;

			if( tm.NowTurn )
			{
				tm.NowTurn = false;
			}
			else
			{
				tm.NowTurn = true;
			}
		}
	}

	void OnTriggerStay2D(Collider2D col)
	{
		
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
		Debug.Log("standardRadius:" + standardRadius);
		Debug.Log("otherPosX:" + otherPos.x);
		Debug.Log("otherPosY:" + otherPos.y);
		Debug.Log("otherRadius:" + otherRadius);
		Debug.Log("distance:" + distance);
		//Debug.Log(/*"moveX:" +*/ playerMove.x);
		//Debug.Log(/*"moveY:" +*/ playerMove.y);

		if (col.gameObject.tag == "Player")
		{
			Vector2 playerMove = col.gameObject.GetComponent<PlayerStatus>().Move;
			isActed = col.gameObject.GetComponent<PlayerStatus>().IsActed;

			// 行動が終わっていて、速度が0の場合
			if (!isActed && playerMove.x <= 0 && playerMove.y <= 0)
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
				isChangedTurn = true;
			}
		}

		if (col.gameObject.tag == "EnemyUnit")
		{
			Vector2 enemyMove = col.gameObject.GetComponent<EnemyStatus>().Move;
			isActed = col.gameObject.GetComponent<EnemyStatus>().IsActed;

			// 行動が終わっていて、速度が0の場合
			if (!isActed && enemyMove.x <= 0 && enemyMove.y <= 0)
			{
				int enemyAttackQty = col.gameObject.GetComponent<EnemyStatus>().Attack;

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
				isChangedTurn = true;
			}
		}
			
	}

}
