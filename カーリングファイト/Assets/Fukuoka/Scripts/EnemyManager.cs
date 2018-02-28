using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public int Life;

    public GameObject Flame;

    GameObject Obj;

    [SerializeField]
    GameObject EnemyLifeGauge = null;

    private void Start()
    {
        EnemyLifeGauge.GetComponent<GaugeController>().SetGaugeMax(Life);
    }

    private void Update()
    {
        EnemyLifeGauge.GetComponent<GaugeController>().SetGaugeValue(Life);
    }


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
        Obj = (GameObject)Instantiate(Resources.Load("Prefab/Enemy"));
        Obj.transform.parent = transform;
        Obj.GetComponent<EnemyStatus>().Attack = nAttack;

        return Obj;
    }
}
