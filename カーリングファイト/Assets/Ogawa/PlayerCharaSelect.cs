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
        if (TM.NowTurn == false)
        {
            if (PUI.PlayerObj == null)
            {
                PUI.PlayerObj = PM.Generate(20);
            }
            else if (PUI.PlayerObj != null)
            {
                if (PUI.PlayerObj.GetComponent<Player>().bUse == false)
                {
                    DestroyImmediate(PUI.PlayerObj);

                    PUI.PlayerObj = PM.Generate(20);
                }
            }
        }
    }
}