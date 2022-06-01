using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;




public class gameController : MonoBehaviour
{

    public float bulletSpeed;
    public float atkSpeed;
    public int barrelCount;
    public int currentShip;
    public float shipSpeed;
    public float EnemySpeed;
    public bool willSave=false;
    public int credits;

    public bool[] boughtShips;


    public bool isGameStarted=false;

    public TMP_Text creditText;
    // Start is called before the first frame update
    
   
    private void Awake()
    {
        if(File.Exists(Application.persistentDataPath + "/playersavedata.hehe"))
        LoadPlayer();

       



    }
    private void Start()
    {
        
    }
    public void LoadPlayer()
    {
       
        PlayerData data = SaveSystem.LoadPlayer();
        credits = data.credits;
        currentShip = data.currentShip;
        boughtShips = data.boughtShip;
        

    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    // Update is called once per frame
    void Update()
    {
        creditText.text = (credits+"");

        if (willSave)
            SavePlayer();
        
    }
}
