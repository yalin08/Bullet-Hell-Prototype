using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerStats : CharacterStats
{
    [SerializeField] float timeToDestroy;
   

    Rigidbody rb;
    [Header("Particle")]
    [SerializeField] GameObject destroyParticle;
    [SerializeField] GameObject hitparticle;



    [Header("UI")]
    [SerializeField] TMP_Text healthText;
    [SerializeField] Image Heart;
    [SerializeField] GameObject loseUI;



    [HideInInspector]public bool isDestroyed;

    shipmodelChange shipmodelChange;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        shipmodelChange = GetComponent<shipmodelChange>();
        maxHealth = shipmodelChange.shipNow[shipmodelChange.currentShip].health;
        health = maxHealth;
        damage = shipmodelChange.shipNow[shipmodelChange.currentShip].damage;
        mvSpeed = shipmodelChange.shipNow[shipmodelChange.currentShip].speed;
        atkSpeed = shipmodelChange.shipNow[shipmodelChange.currentShip].attackSpd;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
         playerLose();

        healthText.text = "" + health;
      
    }
    private void FixedUpdate()
    {
        Heart.fillAmount = (float)health / (float)maxHealth;
    }
    void playerLose()
    {
        GameObject.FindWithTag("Rogue").GetComponent<rogueController>().isDead = true;
        GameObject.FindWithTag("GameController").GetComponent<gameController>().willSave = true;
        GetComponent<BulletSpawn>().enabled = false;
        GetComponent<JoystickPlayerExample>().canMove = false;

        timeToDestroy -= Time.deltaTime;
        if (!isDestroyed)
        {

            rb.useGravity = true;
            var destroyingParticle = Instantiate(destroyParticle, transform.position, Quaternion.identity);
            destroyingParticle.transform.parent = gameObject.transform;
            rb.AddForce(new Vector3(Random.Range(-15, 15), 0, Random.Range(0, 15)), ForceMode.Impulse);
            rb.AddTorque(new Vector3(Random.Range(-180, 180), Random.Range(-50, 50), Random.Range(-30, 30)));
            //  rb.AddForce(transform.right*Time.deltaTime, ForceMode.Force);
        }


        isDestroyed = true;
        if (timeToDestroy <= 0)
        {
            // gameObject.SetActive(false);
            Destroy(gameObject);
            loseUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && other.gameObject.GetComponent<EnemyStats>().canDamage)
        {
            other.gameObject.GetComponent<EnemyStats>().canDamage = false;
            health -= other.GetComponent<EnemyStats>().damage;
           // other.GetComponent<EnemyStats>().getDestroyed();
            Instantiate(hitparticle, other.transform.position, Quaternion.identity);

             if (health < 0)
            {
                    health = 0;
            }
        }



        if (other.gameObject.tag == "enemyBullet" && other.gameObject.GetComponent<enemyBulletGoTo>().canDamage == true)
        {
            other.gameObject.GetComponent<enemyBulletGoTo>().canDamage = false;
            Instantiate(hitparticle, other.transform.position, Quaternion.identity);
            health -= other.gameObject.GetComponent<enemyBulletGoTo>().damage;
               if (health < 0)
            {
                   health = 0;
            }
        }
    }

}
