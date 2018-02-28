using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnUI : MonoBehaviour {

    public GameObject Turn = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        bool b = Turn.GetComponent<TurnManager>().NowTurn;

        if (!b)
        {
            transform.position -= new Vector3(0.3f, 0.0f, 0.0f);
        }
        else
        {
            //if (transform.localPosition.x < 0)
            {
                transform.localPosition = new Vector3(1100f, transform.localPosition.y, transform.localPosition.z);
            }
        }
    }
}
