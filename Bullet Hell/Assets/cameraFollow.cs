using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cameraFollow : MonoBehaviour
{
    [SerializeField] GameObject cam;
    [SerializeField] GameObject player;
    [SerializeField] Vector3 cameraindex;
    Vector3 camStartPos;

    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera");
        player = GameObject.FindWithTag("Player");
        camStartPos = cam.transform.position;
        playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<gameController>();
    }
    PlayerStats playerStats;
    gameController gameController;
    Vector3 vector;
    // Update is called once per frame
    void FixedUpdate()
    {

        if (player == null)
        {
            return ;
        }

       if (gameController.isGameStarted)
        {
            vector = new Vector3(player.transform.position.x, player.transform.position.y + cameraindex.y, player.transform.position.z + cameraindex.z);

        }
        if (!gameController.isGameStarted)
        {
            vector = new Vector3(player.transform.position.x, player.transform.position.y + camStartPos.y, player.transform.position.z + camStartPos.z);

        }



        transform.position = Vector3.Slerp(transform.position, vector, playerStats.mvSpeed*0.9f * Time.deltaTime);
    }
}
