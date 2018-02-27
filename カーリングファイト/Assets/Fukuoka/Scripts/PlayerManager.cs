using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public int Life;

    public GameObject Flame;

    GameObject Obj;

    public void AddLife(int n)
    {
        Life += n;
    }

    public void SubLife(int n)
    {
        Life -= n;
    }

    public GameObject Generate(int nAttack)
    {
        Obj = (GameObject)Instantiate(Resources.Load("Prefab/Player"));
        Obj.transform.parent = transform;
        Obj.GetComponent<PlayerStatus>().Attack = nAttack;

        return Obj;
    }
}
