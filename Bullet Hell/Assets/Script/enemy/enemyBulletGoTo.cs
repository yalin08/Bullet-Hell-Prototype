using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletGoTo : MonoBehaviour
{
    [SerializeField] float timeToDie;
    public float bulletSpawn;

    public bool canDamage=true;

    [SerializeField] GameObject bulletparticle;
    [SerializeField] GameObject hitparticle;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
       
        bulletSpawn = waveSpawner.Instance.enemyBulletSpeed;

        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.x = 90;
        transform.rotation = Quaternion.Euler(rotationVector);

      
    }




    // Update is called once per frame
    void Update()
    {
        timeToDie -= Time.deltaTime;
        if (timeToDie <= 0)
            Destroy(gameObject);


        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - bulletSpawn), Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           
            //Instantiate(hitparticle, transform.position, Quaternion.identity);
            Instantiate(bulletparticle, transform.position, Quaternion.identity);


            Destroy(gameObject);
        }

    }
}
