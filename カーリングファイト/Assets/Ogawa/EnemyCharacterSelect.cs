using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterSelect : MonoBehaviour
{
    [SerializeField]
    private TurnManager TM;

    [SerializeField]
    private EnemyManager EM;

    [SerializeField]
    private EnemyUIManager EUI;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnClick()
    {
        // ストーンを生成
        if (TM.NowTurn == true)
        {
            if (EUI.EnemyObj == null)
            {
                EUI.EnemyObj = EM.Generate(20);
            }
            else if (EUI.EnemyObj != null)
            {
                if (EUI.EnemyObj.GetComponent<Enemy>().bUse == false)
                {
                    DestroyImmediate(EUI.EnemyObj);

                    EUI.EnemyObj = EM.Generate(20);
                }
            }
        }

        
    }
}
