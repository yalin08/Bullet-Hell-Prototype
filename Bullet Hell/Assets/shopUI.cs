using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class shopUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int[] shipPrices;

    [SerializeField] int selectedShipOnShop;
    [SerializeField] GameObject[] shipsOnShop;
   
    [SerializeField] GameObject buyBut;
    [SerializeField] GameObject equipBut;

    [SerializeField] string[] shipNames;

    [SerializeField] TMP_Text shipName;
    [SerializeField] TMP_Text shipPriceText;

    public bool[] boughtShips;

    [SerializeField] GameObject[] atkico;
    [SerializeField] GameObject[] hltico;
    [SerializeField] GameObject[] asico;
    [SerializeField] GameObject[] spdico;

    public void buyShip()
    {
       if (controller.GetComponent<gameController>().credits >= shipPrices[selectedShipOnShop])
        {
            controller.GetComponent<gameController>().credits -= shipPrices[selectedShipOnShop];
            boughtShips[selectedShipOnShop] = true;
            equipShip();
            butChange();
        }
           
    }

    public void equipShip()
    {
        if (boughtShips[selectedShipOnShop] == true)
        {
            controller.GetComponent<gameController>().currentShip = selectedShipOnShop;
            player.GetComponent<shipmodelChange>().currentShip = selectedShipOnShop;
            player.GetComponent<PlayerStats>().health = player.GetComponent<shipmodelChange>().shipNow[selectedShipOnShop].health;
            player.GetComponent<PlayerStats>().maxHealth = player.GetComponent<shipmodelChange>().shipNow[selectedShipOnShop].health;

            controller.GetComponent<gameController>().SavePlayer();
        }
    }

    [SerializeField] GameObject openshopUI;
    public void goBack()
    {
        gameObject.SetActive(false);
        openshopUI.SetActive(true);
    }

    [SerializeField] GameObject controller;
    [SerializeField] GameObject player;
    [SerializeField] GameObject joystick;
    private void Start()
    {


        boughtShips= controller.GetComponent<gameController>().boughtShips ;
        butChange();
        currentshiphlt = player.GetComponent<shipmodelChange>().shipNow[selectedShipOnShop].health - 1;
        currentshipatk = player.GetComponent<shipmodelChange>().shipNow[selectedShipOnShop].damage - 1;
        currentshipas = (int)player.GetComponent<shipmodelChange>().shipNow[selectedShipOnShop].attackSpd - 1;
        currentshipspd = (int)player.GetComponent<shipmodelChange>().shipNow[selectedShipOnShop].speed - 1;
    }

    private void OnEnable()
    {
        selectedShipOnShop = controller.GetComponent<gameController>().currentShip;

    }
    private void OnDisable()
    {
        joystick.SetActive(true);
        player.GetComponent<shipmodelChange>().currentShip = controller.GetComponent<gameController>().currentShip;
        player.GetComponent<shipmodelChange>().maxHealth = player.GetComponent<shipmodelChange>().health;

    }
    void Update()
    {
        shipName.text = shipNames[selectedShipOnShop];
        shipPriceText.text = shipPrices[selectedShipOnShop]+" Credits";
        player.GetComponent<shipmodelChange>().currentShip = selectedShipOnShop;

        joystick.SetActive(false);

        

        for (int i = 0; i < atkico.Length; i++)
        {
            atkico[i].SetActive(false);
        }for (int i = 0; i < hltico.Length ; i++)
        {
            hltico[i].SetActive(false);
        }for (int i = 0; i < asico.Length ; i++)
        {
            asico[i].SetActive(false);
        }for (int i = 0; i < spdico.Length ; i++)
        {
            spdico[i].SetActive(false);
        }

      


        for (int i = currentshipatk; i >= 0; i--)
        {
            atkico[i].SetActive(true); 
        }for (int i = currentshiphlt; i >= 0; i--)
        {
            hltico[i].SetActive(true); 
        }for (int i = currentshipas; i >= 0; i--)
        {
            asico[i].SetActive(true); 
        }for (int i = currentshipspd; i >= 0; i--)
        {
            spdico[i].SetActive(true); 
        }

    }

    int currentshiphlt; int currentshipatk; int currentshipas; int currentshipspd;
    public void butChange()
    {
        currentshiphlt = player.GetComponent<shipmodelChange>().shipNow[selectedShipOnShop].health - 1;
        currentshipatk = player.GetComponent<shipmodelChange>().shipNow[selectedShipOnShop].damage - 1;
        currentshipas = (int)player.GetComponent<shipmodelChange>().shipNow[selectedShipOnShop].attackSpd - 1;
        currentshipspd = (int)player.GetComponent<shipmodelChange>().shipNow[selectedShipOnShop].speed - 1;



        if (boughtShips[selectedShipOnShop] == true)
        {
            buyBut.SetActive(false);
            equipBut.SetActive(true);
        }
        else if (boughtShips[selectedShipOnShop] == false)
        {
            equipBut.SetActive(false);
            buyBut.SetActive(true);
        }
    }
    public void prevBut()
    {
        if(selectedShipOnShop==0)
            selectedShipOnShop = shipsOnShop.Length-1;
        else

        selectedShipOnShop--;


        butChange();
    }
    public void forwBut()
    {
        if (selectedShipOnShop == shipsOnShop.Length-1)
            selectedShipOnShop = 0;
        else

        selectedShipOnShop++;


        butChange();
    }
}
