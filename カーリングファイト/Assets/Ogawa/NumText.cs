using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumText : MonoBehaviour
{
    [SerializeField]
    private Text Tx;

    [SerializeField]
    private GaugeController Gc;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Tx.text = "HP" + Gc.Value.ToString() + "/" + Gc.MaxValue.ToString();
    }
}
