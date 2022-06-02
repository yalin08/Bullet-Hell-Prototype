using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class runnerEnemyMind : MonoBehaviour
{
    
     float EnemySpeed;
    EnemyStats enemystats;
    public bool canDamage = true;
    
    
    // Start is called before the first frame update
    void Start()
    {
        enemystats = GetComponent<EnemyStats>();
        randomcount = Random.Range(4f, 10f);

        player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            return;
        }
      
        EnemySpeed =enemystats.mvSpeed*2;
        
        
        
    }
   
  
    GameObject player;
    
 

   public float _distance;
    void Update()
    {
        if (player == null)
        {
            return;
        }
     

        if (gameObject.transform.position.z <= player.transform.position.z-10)
        {
            enemystats.getDestroyed();
        }






        _distance = (Vector3.Distance(player.transform.position, transform.position));
        if (_distance < distanceForChargeUp)
        {
            isChargingForAttack = true;
            Debug.Log("enemy charges");
        }
       
           


      if (isChargingForAttack)
        {
            chargeForAttack();
        }
      else
        {
            moveTowardsPlayer();
        }
    }

    Vector3 _direction;
    Quaternion _lookRotation;


   bool isChargingForAttack;
     bool attacking;
    float randomcount;
    void moveTowardsPlayer()
    {
        Vector3 vector;
        
        float f;
       

        if (transform.position.x > player.transform.position.x)
            f = randomcount;
        else
        {
            f = -randomcount;
        }

       vector = new Vector3(player.transform.position.x+f, player.transform.position.y, player.transform.position.z-1.5f);
        _direction = (transform.position- player.transform.position).normalized;
        _lookRotation = Quaternion.LookRotation(_direction);
        transform.position = Vector3.MoveTowards(transform.position, vector, EnemySpeed*Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, _lookRotation, Time.deltaTime * EnemySpeed);
    }

    Vector3 _lastknownPosition;
    float chargetimer;
    public float distanceForChargeUp;
    
    void chargeForAttack()
    {
        if (chargetimer > 0)
        {
            chargetimer -= Time.deltaTime;
        _direction = (transform.position - player.transform.position).normalized;
        _lookRotation = Quaternion.LookRotation(_direction);
        _lastknownPosition = player.transform.position;

            _lastknownPosition.x = player.transform.position.x ;



        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * EnemySpeed);
        transform.position = Vector3.MoveTowards(transform.position, _lastknownPosition, -EnemySpeed*Time.deltaTime/2);
        }
        else
        {
            attackPlayer();
        }



    }
    void attackPlayer()
    {

        if (!enemystats.isDestroyed)
        {
            if(transform.position==_lastknownPosition)
          _lastknownPosition.z = -8;


       
        transform.position = Vector3.MoveTowards(transform.position, _lastknownPosition, EnemySpeed * Time.deltaTime*2f);
            enemystats.rb.AddTorque(new Vector3(0, 0,45));

        }

    }
  
 

    private void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.tag == "Player")
        {
            enemystats.health = 0;
        }
    }
}
