using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class plusCredit : MonoBehaviour
{
    public TMP_Text creditCount;
    public bool showCredit ;
    // Start is called before the first frame update
    void Start()
    {
        showCredit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (showCredit)
        {
            Vector3 creditPos = Camera.main.WorldToScreenPoint(this.transform.position);
            creditCount.transform.position = creditPos;
            showCredit = false;
        }
    }
}
