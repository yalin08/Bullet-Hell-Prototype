using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Pixelplacement;
[System.Serializable]
public class Wave
{
    public string waveName;
    public int numOfEnemies;
    
   

    public GameObject[] typeOfEnemies;
    
    public float spawnInterval;
    [HideInInspector]public int numOfEnemiesDef;




}


public class waveSpawner : Singleton<waveSpawner>
{
    public int enemyHealthMultiplier;
    public float enemySpeedMultiplier;
    [SerializeField] GameObject Enemy2;
    [SerializeField] Wave[] waves;
    public Transform[] spawnPoint;
    public float enemyBulletSpeed;
    public float enemyatkspd;
    private Wave currentWave;
    [SerializeField] int currentWaveNumber;
    private float nextSpawnTime;

    public int enemyDamage;
  

    public int loopcount=0;

    public int WaveNumberForUi;
    

    private bool canSpawn = true;
    public bool gameStarted = false;


    shipmodelChange shipchange;
    BulletSpawn bulletSpawn;

    JoystickPlayerExample joystickscript;
    PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = player.GetComponent<PlayerStats>();
        shipchange = shipmodelChange.Instance;
        bulletSpawn = BulletSpawn.Instance;
        joystickscript = JoystickPlayerExample.Instance;
        currentcolor = skyboxDefault;
        skyBoxColor = skyboxDefault;

        currentStarColor = starDefault;

        loopTimerBase = loopTimer;
        for (int i = 0; i < waves.Length; i++)
        {
            Debug.Log("asd");
            waves[i].numOfEnemiesDef = waves[i].numOfEnemies;
            waves[i].waveName = "Wave"+i;
        }
    }

    [SerializeField] GameObject starParticle;
    bool isStarParticleActive;
    [SerializeField] float gameStartsIn;
    [SerializeField] TMP_Text Wave;
    public float loopTimer;
    float loopTimerBase;
    [SerializeField] GameObject WaveObject;
    // Update is called once per frame
    void Update()
    {
        currentcolor = Color.Lerp(currentcolor, skyBoxColor, Time.deltaTime);
        currentStarColor = Color.Lerp(currentStarColor, starColor, 2*Time.deltaTime);
        RenderSettings.skybox.SetColor("_Tint", currentcolor);

        var starparticle = stars.gameObject.GetComponent<ParticleSystem>().main;
        var star2particle = stars2.gameObject.GetComponent<ParticleSystem>().main;

        starparticle.startColor = currentStarColor;
        star2particle.startColor = currentStarColor;

        Wave.text = ("Wave " + WaveNumberForUi);
        if (gameStarted&&gameStartsIn>0) {
            gameStartsIn -= Time.deltaTime;
            if (!isStarParticleActive)
            {
               starParticle.SetActive(true);
                isStarParticleActive = true;
                bulletSpawn.enabled = true;
               joystickscript.isGameStarted = true; 
        }

          
        }


        if (waves.Length == currentWaveNumber) {

            Loop();
        }

        currentWave = waves[currentWaveNumber];

        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");

        
        if (totalEnemies.Length==0&& !canSpawn )
        {
           
            SpawnNextWave();
        }

        
    }

    bool b = false;
    void SpawnNextWave()
    {
       
       if (currentWaveNumber +1 == waves.Length && !b)
        {
            resetStars();
            b = true;
           
        }
        if (loopTimerBase > 0)
        {
            loopTimerBase -= Time.deltaTime;
        }
        else
        {
            b = false;
            WaveObject.SetActive(true);
            currentWaveNumber++;
        WaveNumberForUi++;

        canSpawn = true;
            loopTimerBase = loopTimer;
        }
       
    }

    void SpawnWave()
    {
        if (canSpawn &&  nextSpawnTime<Time.time && gameStarted&& gameStartsIn<=0) { 
        GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
        Transform randomPoint = spawnPoint[Random.Range(0, spawnPoint.Length)];
        Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            currentWave.numOfEnemies--;
            nextSpawnTime = Time.time + currentWave.spawnInterval;

            if (currentWave.numOfEnemies == 0)
                canSpawn = false;
        }
    }

    void resetStars()
    {
        if (player.GetComponent<PlayerStats>().isDestroyed == false)
        {
            Debug.Log("stars reset");
            Animator staranim = stars.GetComponentInChildren<Animator>();
            Animator star2anim = stars2.GetComponentInChildren<Animator>();

            staranim.Rebind();
            star2anim.Rebind();
        }
       


    }

    public ParticleSystem stars;
    public ParticleSystem stars2;
    Color currentcolor;
    Color currentStarColor;
    [SerializeField] GameObject player;
   
    void Loop()
    {
        float r;
        float g;
        float b;

        r = Random.Range(0.05f, 0.4f);
        g = Random.Range(0.05f, 0.4f);
        b = Random.Range(0.05f, 0.4f);


        
      
        skyBoxColor = new Color(r, g, b);
        starColor = new Color(Random.Range(0.8f,1f) - skyBoxColor.r, Random.Range(0.8f, 1f) - skyBoxColor.g, Random.Range(0.8f, 1f) - skyBoxColor.b);





        playerStats.health = playerStats.maxHealth;
       



       
        loopcount++;
        currentWaveNumber = 0;  
        currentWave.numOfEnemies = currentWave.numOfEnemiesDef * (loopcount);
        enemyHealthMultiplier += loopcount;
        enemySpeedMultiplier = enemySpeedMultiplier + (0.2f * loopcount);
        enemyBulletSpeed = enemyBulletSpeed + (0.2f * loopcount);
        enemyDamage += loopcount;
        enemyatkspd += enemyatkspd / 4;


        for (int i = 0; i < waves.Length; i++)
        {
            
            waves[i].spawnInterval = waves[i].spawnInterval / ( waves[i].spawnInterval + 0.1f * loopcount);
            waves[i].numOfEnemies = (int)(waves[i].numOfEnemiesDef * ( waves[i].numOfEnemiesDef + 0.1f * loopcount));


            
           

            if (loopcount >= 2)
                waves[i].typeOfEnemies[waves[i].typeOfEnemies.Length-1] = Enemy2;
        }
        
    }
    [SerializeField] Color skyboxDefault;
    public Color starDefault;
    public Color skyBoxColor;
    public Color starColor;
}
