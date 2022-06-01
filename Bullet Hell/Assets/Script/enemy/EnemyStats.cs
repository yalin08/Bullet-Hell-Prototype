using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyStats : CharacterStats
{

    public float spawnKillProtection;
    [SerializeField] float timeToDestroy;
    [Header("Particles")]
    [SerializeField] GameObject hitParticle;
    [SerializeField] GameObject destroyParticle;
    
    
    [HideInInspector]public Rigidbody rb;
    
    [Header("UI")]
    public TMP_Text creditValue;
    public GameObject creditvaluePos;
    public GameObject creditvalueCanvas;
    gameController gameController;
    [HideInInspector]public bool isDestroyed = false;

    [HideInInspector]public bool canDamage = true;
    [HideInInspector]public int value;
   
    private void Awake()

    {
        gameController = gameController.Instance;
        mvSpeed = waveSpawner.Instance.enemySpeedMultiplier * 1;
        atkSpeed = waveSpawner.Instance.enemyatkspd;
        health = waveSpawner.Instance.enemyHealthMultiplier;
        maxHealth = health;
        damage = waveSpawner.Instance.enemyDamage;

    }
    void Start()
    {
     
        value = (int)(Random.Range(5, 10) * (waveSpawner.Instance.loopcount + 1) / 2);
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnKillProtection > 0)
            spawnKillProtection -= Time.deltaTime;

        if (health <= 0)
        {

            getDestroyed();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" && spawnKillProtection <= 0)
        {
            health -= other.gameObject.GetComponent<bulletGoTo>().damage;

            if (health > 0)
                Instantiate(hitParticle, transform.position, Quaternion.identity);
        }
    }
    bool didGaveMoney;
    bool didGaveXp = false;

    public void getDestroyed()
    {
        if(GetComponent<enemy1ShootBullet>()!=null)
        GetComponent<enemy1ShootBullet>().enabled = false;

        if (!didGaveMoney)
        {
            didGaveMoney = true;
            creditvaluePos.GetComponent<plusCredit>().showCredit = true;


            creditValue.text = ("+" + value);

            gameController.credits += value;
            creditvaluePos.GetComponent<destroyAfterEnemy>().timerStarted = true;
            creditvalueCanvas.GetComponent<destroyAfterEnemy>().timerStarted = true;


        }

        gameObject.tag = "Untagged";
        timeToDestroy -= Time.deltaTime;
        if (!isDestroyed)
        {
            mvSpeed = 0;
            rb.useGravity = true;
            var destroyingParticle = Instantiate(destroyParticle, transform.position, Quaternion.identity);
            destroyingParticle.transform.parent = gameObject.transform;
            rb.AddForce(new Vector3(Random.Range(-15, 15), 0, 0), ForceMode.Impulse);
            rb.AddTorque(new Vector3(Random.Range(-35, 35), Random.Range(-25, 25), Random.Range(-20, 20)));


            if (!didGaveXp)
            {
                rogueController.Instance.xp += Random.Range(3, 5);
                didGaveXp = true;
            }
            //  rb.AddForce(transform.right*Time.deltaTime, ForceMode.Force);
        }


        isDestroyed = true;
        if (timeToDestroy <= 0)
        {

            Destroy(gameObject);
        }
    }
}
