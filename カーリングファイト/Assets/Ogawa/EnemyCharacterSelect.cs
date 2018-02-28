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

    [SerializeField]
    private int NumChara;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (EUI.EnemyObj != null)
        {
            if (EUI.EnemyObj.GetComponent<Player>().bUse == true)
            {
                EUI.EnemyObj = null;
            }
        }
    }

    public void OnClick()
    {
        // ストーンを生成
        if (TM.NowTurn == true)
        {
            if (EUI.EnemyObj == null)
            {
                switch (NumChara)
                {
                    case 1:
                        EUI.EnemyObj = EM.Generate(100);
                        EUI.EnemyObj.GetComponent<Enemy>().SetCharaType(1);
                        break;

                    case 2:
                        EUI.EnemyObj = EM.Generate(200);
                        EUI.EnemyObj.GetComponent<Enemy>().SetCharaType(2);
                        break;

                    case 3:
                        EUI.EnemyObj = EM.Generate(300);
                        EUI.EnemyObj.GetComponent<Enemy>().SetCharaType(3);
                        break;

                    case 4:
                        EUI.EnemyObj = EM.Generate(400);
                        EUI.EnemyObj.GetComponent<Enemy>().SetCharaType(4);
                        break;
                }
            }
            else if (EUI.EnemyObj != null)
            {
                if (EUI.EnemyObj.GetComponent<Enemy>().bUse == false)
                {
                    DestroyImmediate(EUI.EnemyObj);

                    switch (NumChara)
                    {
                        case 1:
                            EUI.EnemyObj = EM.Generate(100);
                            EUI.EnemyObj.GetComponent<Enemy>().SetCharaType(1);
                            break;

                        case 2:
                            EUI.EnemyObj = EM.Generate(200);
                            EUI.EnemyObj.GetComponent<Enemy>().SetCharaType(2);
                            break;

                        case 3:
                            EUI.EnemyObj = EM.Generate(300);
                            EUI.EnemyObj.GetComponent<Enemy>().SetCharaType(3);
                            break;

                        case 4:
                            EUI.EnemyObj = EM.Generate(400);
                            EUI.EnemyObj.GetComponent<Enemy>().SetCharaType(4);
                            break;
                    }
                }
            }
        }

        
    }
}
