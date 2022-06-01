using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletGoTo : MonoBehaviour
{
    [SerializeField] float timeToDie;
    [SerializeField] float bulletSpawn;


    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpawn = GameObject.FindWithTag("Player").GetComponent<BulletSpawn>().bulletSpeed;

        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.x = 90;
        transform.rotation = Quaternion.Euler(rotationVector);
        playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        damage = playerStats.damage;
    }

    PlayerStats playerStats;


    // Update is called once per frame
    void Update()
    {
        timeToDie -= Time.deltaTime;
        if (timeToDie <= 0)
            Destroy(gameObject);
       
        
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z+bulletSpawn), Time.deltaTime);
    }

    [SerializeField] GameObject particuleDestroy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {



            Instantiate(particuleDestroy,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
       
        if (other.gameObject.tag == "enemyBullet")
        {
            var otherbulletdamage = other.gameObject.GetComponent<enemyBulletGoTo>().damage;

            if (damage > otherbulletdamage)
            {
                Instantiate(particuleDestroy,other.transform.position,Quaternion.identity);
                damage -= otherbulletdamage;
                Destroy(other.gameObject);
            }
            else if (otherbulletdamage < damage)
            {
                Instantiate(particuleDestroy,gameObject.transform.position,Quaternion.identity); 
                otherbulletdamage -= damage;
                Destroy(gameObject);
            }
            else
            {
                Instantiate(particuleDestroy, other.transform.position, Quaternion.identity);
                Instantiate(particuleDestroy,gameObject.transform.position, Quaternion.identity);
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }

    }

}
