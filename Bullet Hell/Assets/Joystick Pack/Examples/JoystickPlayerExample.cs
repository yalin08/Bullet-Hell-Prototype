using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    PlayerStats playerStats;
    gameController gameController;

    [SerializeField] Vector3 playerToGo;

     public bool isGameStarted=false;
    public bool canMove=false;
    [SerializeField] float moveLimit;

    private void Start()
    {
        playerStats=GetComponent<PlayerStats>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<gameController>();
    }
    [SerializeField] GameObject startgamebutton;
    [SerializeField] GameObject wavereminder;
    public void startTheGame()
    {
        startgamebutton.SetActive(false);
        wavereminder.SetActive(true);
        isGameStarted = true;
        GameObject.FindWithTag("LevelController").GetComponent<waveSpawner>().gameStarted = true;
        GameObject.FindWithTag("Player").GetComponent<shipmodelChange>().gameStarted = true;
        gameController.isGameStarted = true;
    }
    public void Update()
    {
        
        if (direction != new Vector3(0, 0, 0) && !isGameStarted)
        {
            startTheGame();
        }
    }
    Vector3 direction;
    public void FixedUpdate()
    {
        speed = (gameController.shipSpeed) * playerStats.mvSpeed ;
        direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        // rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        
          
        if(canMove)
        { 
        playerToGo = new Vector3(
            Mathf.Clamp(
            transform.position.x + variableJoystick.Horizontal* Time.deltaTime*speed,-70,70)
            , 

            transform.position.y,

            Mathf.Clamp(transform.position.z + variableJoystick.Vertical* Time.deltaTime*speed,-7f,40)
            
            
            );

        transform.position = Vector3.Lerp(transform.position, playerToGo, speed);
        _targetRotation.x = variableJoystick.Vertical/15;
        _targetRotation.y = variableJoystick.Horizontal/10;
        _targetRotation.z = -variableJoystick.Horizontal/3;
        transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, speed * Time.deltaTime);
        }

        //  transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6f, 6f), transform.position.y, Mathf.Clamp(transform.position.x, -2f, 10f));
    }
    private Quaternion _targetRotation = Quaternion.identity;
}