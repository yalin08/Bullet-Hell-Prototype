using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class destroyAfterEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Color fadeAway;
    void Start()
    {
        
    }
   [SerializeField] float timer;
    [SerializeField] bool no=false;
    public bool timerStarted=false;
    [SerializeField] TMP_Text self;
    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            timer -= Time.deltaTime;

            if (timer <= 0.3&& no)
                self.color = Color.Lerp(self.color, fadeAway, Time.deltaTime*15);

            if (timer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
