using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class openShopUI : MonoBehaviour
{
    [SerializeField] GameObject shopUI;
    [SerializeField] GameObject self;
    public void openShop()
    {
        shopUI.SetActive(true);
        self.SetActive(false);
    }
}
