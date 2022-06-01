using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class BulletSpawn : Singleton<BulletSpawn>
{
    // Start is called before the first frame update

    public float bulletSpeed;
    public float atkSpeed;
    public int  barrelCount;
    [SerializeField] GameObject[] barrels;
    [SerializeField] float timerForAtkSpd;
    [SerializeField] GameObject bullet;
    void Start()
    {
        gameController = gameController.Instance;
        atkSpeed = gameController.atkSpeed;
        bulletSpeed = gameController.bulletSpeed;
        barrelCount = gameController.barrelCount;
        
        playerStats = GetComponent<PlayerStats>();
        timerForAtkSpd = 2/atkSpeed;
    }

    gameController gameController;
    PlayerStats playerStats;
    // Update is called once per frame
    void Update()
    {
        atkSpeed = gameController.atkSpeed * playerStats.atkSpeed;
        timerForAtkSpd -= Time.deltaTime;
        if (timerForAtkSpd <= 0)
        {
            if(barrelCount==1)
                Instantiate(bullet, barrels[0].transform.position, Quaternion.identity);
            else if (barrelCount == 2) { 
                Instantiate(bullet, barrels[1].transform.position, Quaternion.identity);
                Instantiate(bullet, barrels[2].transform.position, Quaternion.identity);
            }
            else if (barrelCount >= 3)
            {
                Instantiate(bullet, barrels[0].transform.position, Quaternion.identity);
                Instantiate(bullet, barrels[1].transform.position, Quaternion.identity);
                Instantiate(bullet, barrels[2].transform.position, Quaternion.identity);
            }



            timerForAtkSpd = 2/atkSpeed;
        }
    }
}
