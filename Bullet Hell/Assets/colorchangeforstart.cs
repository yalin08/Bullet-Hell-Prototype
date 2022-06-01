using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class colorchangeforstart : MonoBehaviour
{
    [SerializeField] Color color1; [SerializeField] Color color2; [SerializeField] Color colorNow;


    [SerializeField] float timer; [SerializeField] float timerold;

    [SerializeField] TMP_Text slidetostart;
    // Start is called before the first frame update
    void Start()
    {
        slidetostart.color = color1;
        colorNow = color1;
        timer = timerold;
    }
    [SerializeField] float fadetime;
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= timerold - (timerold / 2))
        {
            colorNow = color2;
        }
        if (timer <= 0)
        {
            colorNow = color1;
            timer = timerold;
        }

        slidetostart.color = Color.Lerp(slidetostart.color, colorNow, fadetime * Time.deltaTime);

    }
}
