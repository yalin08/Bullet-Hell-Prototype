using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Pixelplacement;
public enum whichpowerup
{
    attack, speed, atkspeed, health,projectilespeed, projectilecount
}
public class levellingUpScript : MonoBehaviour
{
    [SerializeField] TMP_Text butText1;
    [SerializeField] TMP_Text butText2;

    [SerializeField] string[] text;
    public whichpowerup powerUp;
   public int but1;
    int but2;
   [SerializeField] GameObject player;
    BulletSpawn bulletspawn;
    [SerializeField] GameObject self;
    PlayerStats playerStats;
    // Start is called before the first frame update
    private void OnEnable()
    {
        playerStats = player.GetComponent<PlayerStats>();
        int i=1;

        if (player.GetComponent<BulletSpawn>().enabled)
        {
            if (player.GetComponent<BulletSpawn>().barrelCount >= 3)
            {
                i = 0;
            }
        }

        Time.timeScale = 0;
        but1 = Random.Range((int)whichpowerup.attack, (int)whichpowerup.projectilecount + i);
        but2 = Random.Range((int)whichpowerup.attack, (int)whichpowerup.projectilecount + i);
        while (but1 == but2)
        {
            but2 = Random.Range((int)whichpowerup.attack, (int)whichpowerup.projectilecount + i);
        }

        
        butText1.text = text[but1];
        butText2.text = text[but2];

    }

    public void buttonpress1()
    {
       
       
        switch (but1)
        {
            case 0:
                playerStats.damage++;
                break;
            case 1:
                playerStats.mvSpeed += playerStats.mvSpeed / 4;
                break;
            case 2:
                playerStats.atkSpeed += playerStats.atkSpeed / 4;
                break;
            case 3:
                playerStats.maxHealth++;
                playerStats.health++;
                break;
                case 4:
                player.GetComponent<BulletSpawn>().bulletSpeed += player.GetComponent<BulletSpawn>().bulletSpeed / 4;
                break;
               
            case 5:
                player.GetComponent<BulletSpawn>().barrelCount++;
                break;
        }
        self.gameObject.SetActive(false);
    }
    public void buttonpress2()
    {
        
        
        switch (but2)
        {
            case 0:
                playerStats.damage++;
                break;
            case 1:
                playerStats.mvSpeed += playerStats.mvSpeed / 4;
                break;
            case 2:
                playerStats.atkSpeed += playerStats.atkSpeed / 4;
                break;
            case 3:
                playerStats.maxHealth++;
                playerStats.health++;
                break;
            case 4:
                player.GetComponent<BulletSpawn>().bulletSpeed += player.GetComponent<BulletSpawn>().bulletSpeed / 4;
                break;
            case 5:
                player.GetComponent<BulletSpawn>().barrelCount++;
                break;
               
        }
        self.gameObject.SetActive(false);
    }
    private void Start()
    {
       
           
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
