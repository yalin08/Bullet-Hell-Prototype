using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class normalEnemyMind : MonoBehaviour
{
    // Start is called before the first frame update
    
   [HideInInspector] public float EnemySpeed;
   // public int health=1;
    public bool canDamage= true;
    GameObject player;

    void Start()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
        player = GameObject.FindWithTag("Player");
        EnemySpeed = GetComponent<EnemyStats>().mvSpeed;
       

    }

 

    // Update is called once per frame

   
    void Update()
    {
       


        if (player == null)
        {
            return;
        }

       


        if (gameObject.transform.position.z <= -8)
        {
            canDamage = true;
            Vector3 spawnArea;
            waveSpawner waveSpawner =waveSpawner.Instance;
            spawnArea = waveSpawner.spawnPoint[Random.Range(0, waveSpawner.spawnPoint.Length)].transform.position;
            transform.position = spawnArea;
            gameObject.tag = "Enemy";
        }
           
       


     
        float xtomove = 0;
        xtomove = Mathf.Lerp(xtomove, player.transform.position.x,EnemySpeed*Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(xtomove, transform.position.y, -8.1f ), EnemySpeed* Time.deltaTime);
    }

  


}
