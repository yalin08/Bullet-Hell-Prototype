using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnpoints : MonoBehaviour
{
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            return;
        }

      Vector3 vector= new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        transform.position = vector;
    }
}
