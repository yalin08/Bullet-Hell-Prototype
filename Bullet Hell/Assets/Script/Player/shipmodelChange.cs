using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Pixelplacement;

[System.Serializable]
public class ShipChange
{
    public float attackSpd;
    public float speed;
    public int health;
    public int damage;
  //  public Collider col;
    

    public GameObject particleMoving;
}
public class shipmodelChange : Singleton<shipmodelChange>
{
    Animator animator;
    public int currentShip;

    [SerializeField] GameObject[] shipModels;
    public ShipChange[] shipNow;
    public float speedMultiplier;
    public float attackSpeed;
   public int maxHealth;
   public int health;
   public int damage;
    
   
    // Start is called before the first frame update
    
    bool shipstatslock = false;
    void Start()
    {
        currentShip = gameController.Instance.currentShip;
        animator = GetComponent<Animator>();
     
        
        foreach (var obj in shipModels)
            obj.SetActive(false);

        shipModels[currentShip].SetActive(true);

       
            shipNow[currentShip].particleMoving.SetActive(false);

        playerStats = GetComponent<PlayerStats>();
        
    }
    PlayerStats playerStats;
    [SerializeField] float particleSpawnAfterGameStarts;
   [HideInInspector] public bool gameStarted;
    public bool canMove=false;
    [SerializeField] Animator animCam;
    // Update is called once per frame
   
    [SerializeField] GameObject openShopUI;
    void Update()
    {
        if (!gameStarted)
        {
            shipNow[currentShip].particleMoving.SetActive(false);
        }

       
     



    
        foreach (var obj in shipModels)
            obj.SetActive(false);

        shipModels[currentShip].SetActive(true);


    


        if (gameStarted)
        {
 openShopUI.SetActive(false);
          


          if (shipstatslock == false)
            {
                shipstatslock = true;
                playerStats.maxHealth = shipNow[currentShip].health;
                playerStats.health = playerStats.maxHealth;
                playerStats.damage = shipNow[currentShip].damage;
                playerStats.mvSpeed = shipNow[currentShip].speed;
                playerStats.atkSpeed = shipNow[currentShip].attackSpd;





            }
          
        }
           


        if (gameStarted && particleSpawnAfterGameStarts > 0)
        {
            animCam.SetBool("liftOff", true);
            animator.SetBool("liftoffStarted", true);
            particleSpawnAfterGameStarts -= Time.deltaTime;
            if (particleSpawnAfterGameStarts <= 1)
            {
shipNow[currentShip].particleMoving.SetActive(true);
                
               
            }
 if (particleSpawnAfterGameStarts <= 0)
            {
                JoystickPlayerExample.Instance.canMove = true;
                animator.enabled = false;
                animCam.enabled = false;
            }
         
        }



      

    }

  

   
}
