using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1ShootBullet : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField] GameObject barell;
    EnemyStats EnemyStats;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        EnemyStats = GetComponent<EnemyStats>();
        atkSpeed = EnemyStats.atkSpeed;
        timerForAtkSpd =  1.5f /atkSpeed;
    }

    public float atkSpeed;
    [SerializeField] float timerForAtkSpd;

    // Update is called once per frame
    void Update()
    {
        damage = EnemyStats.damage;
        timerForAtkSpd -= Time.deltaTime;
        if (timerForAtkSpd <= 0)
        {
              GameObject Bullet=  Instantiate(bullet, barell.transform.position, Quaternion.identity);

            Bullet.GetComponent<enemyBulletGoTo>().damage = damage;



            timerForAtkSpd = 15 / atkSpeed;
        }
    }
}
