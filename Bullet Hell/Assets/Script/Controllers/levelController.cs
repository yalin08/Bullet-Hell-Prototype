using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelController : MonoBehaviour
{

    public int wave;
    public int enemycount;
    public float spawnTimer;
    public float waveTimer;

    public int enemiesWillSpawn;

    public int currentEnemy;
    int beforeX;
    int spawnX;

    public Vector3 enemySpawnPoint;

    [SerializeField] float spawnTimerNow;
    [SerializeField] float waveTimerNow;

    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimerNow = spawnTimer;
        waveTimerNow = waveTimer;
        beforeX = spawnX;
    }

    // Update is called once per frame
    void Update()
    {
        currentEnemy = GameObject.FindGameObjectsWithTag("Enemy").Length;


        if (currentEnemy == 0)
        {

            enemiesWillSpawn = (wave + wave * wave / 2);

           




        }

        if (enemiesWillSpawn > 0)
        {
            
            if (beforeX == spawnX) {
                spawnX = Random.Range(-6, 6);
                enemySpawnPoint = new Vector3(spawnX, 0,60);
            beforeX = spawnX;
            }
            Instantiate(enemy1, enemySpawnPoint, Quaternion.identity);
            enemiesWillSpawn--;

        }
    }
   
  
}
