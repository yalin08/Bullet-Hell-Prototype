using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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
public class shipmodelChange : MonoBehaviour
{
    Animator animator;
    public int currentShip;

    [SerializeField] GameObject[] ships;
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
        currentShip = GameObject.FindWithTag("GameController").GetComponent<gameController>().currentShip;
        animator = GetComponent<Animator>();
     
        
        foreach (var obj in ships)
            obj.SetActive(false);

        ships[currentShip].SetActive(true);

       
            shipNow[currentShip].particleMoving.SetActive(false);

        playerStats = GetComponent<PlayerStats>();
        
    }
    PlayerStats playerStats;
    [SerializeField] float particleSpawnAfterGameStarts;
    public bool gameStarted;
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

       
     



    
        foreach (var obj in ships)
            obj.SetActive(false);

        ships[currentShip].SetActive(true);


    


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
                GetComponent<JoystickPlayerExample>().canMove = true;
                animator.enabled = false;
                animCam.enabled = false;
            }
         
        }



      

    }

  

   
}
