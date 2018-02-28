using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharaSelect : MonoBehaviour
{
    [SerializeField]
    private TurnManager TM;
    [SerializeField]
    private PlayerManager PM;
    [SerializeField]
    private PlayerUIManager PUI;

    [SerializeField]
    private int NumChara;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PUI.PlayerObj != null)
        {
            if (PUI.PlayerObj.GetComponent<Player>().bUse == true)
            {
                PUI.PlayerObj = null;
            }
        }
    }

    public void OnClick()
    {
        // ストーンを生成
        if (TM.NowTurn == false)
        {
            if (PUI.PlayerObj == null)
            {
                switch (NumChara)
                {
                    case 1:
                        PUI.PlayerObj = PM.Generate(100);
                        PUI.PlayerObj.GetComponent<Player>().SetCharaType(1);
                        break;

                    case 2:
                        PUI.PlayerObj = PM.Generate(200);
                        PUI.PlayerObj.GetComponent<Player>().SetCharaType(2);
                        break;

                    case 3:
                        PUI.PlayerObj = PM.Generate(300);
                        PUI.PlayerObj.GetComponent<Player>().SetCharaType(3);
                        break;

                    case 4:
                        PUI.PlayerObj = PM.Generate(400);
                        PUI.PlayerObj.GetComponent<Player>().SetCharaType(4);
                        break;
                }
            }
            else if (PUI.PlayerObj != null)
            {
                if (PUI.PlayerObj.GetComponent<Player>().bUse == false)
                {
                    DestroyImmediate(PUI.PlayerObj);

                    switch (NumChara)
                    {
                        case 1:
                            PUI.PlayerObj = PM.Generate(100);
                            PUI.PlayerObj.GetComponent<Player>().SetCharaType(1);
                            break;

                        case 2:
                            PUI.PlayerObj = PM.Generate(200);
                            PUI.PlayerObj.GetComponent<Player>().SetCharaType(2);
                            break;

                        case 3:
                            PUI.PlayerObj = PM.Generate(300);
                            PUI.PlayerObj.GetComponent<Player>().SetCharaType(3);
                            break;

                        case 4:
                            PUI.PlayerObj = PM.Generate(400);
                            PUI.PlayerObj.GetComponent<Player>().SetCharaType(4);
                            break;
                    }
                }
            }
        }
    }
}