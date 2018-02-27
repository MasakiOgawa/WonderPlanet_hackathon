using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

    Vector2 StartPos;
    Vector2 EndPos; 

    public Vector2 VecPower
    {
        get;
        set;
    }

    // Use this for initialization
    void Awake () {
        StartPos = new Vector2(0, 0);
        EndPos = new Vector2(0, 0);
        VecPower = new Vector2(0, 0);
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartPos = new Vector2(Input.mousePosition.x,
                                        Input.mousePosition.y);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            EndPos = new Vector2(Input.mousePosition.x,
                                      Input.mousePosition.y);
            Direction();
        }

    }

    void Direction()
    {
        float directionX = EndPos.x - StartPos.x;
        float directionY = EndPos.y - StartPos.y;

        VecPower = new Vector2(directionX, directionY);
    }

}
