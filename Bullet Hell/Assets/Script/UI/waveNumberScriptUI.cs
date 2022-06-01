using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Pixelplacement;


public class waveNumberScriptUI : MonoBehaviour
{
 // Tween.LocalScale(boost.transform, Vector3.zero, new Vector3(1.1f, 1.1f, 1.1f), 0.4f, 0, Tween.EaseIn);
    [SerializeField] TMP_Text self;
    // Start is called before the first frame update
    private void OnEnable()
    {
        
       
        Tween.LocalScale(gameObject.transform, Vector3.zero, Vector3.one, 0.4f, 0, Tween.EaseBounce);
    }
    float timer = 1.5f;
    bool easeout = true;
    // Update is called once per frame
    void Update()
    {
        self.text = "Wave " + GameObject.FindWithTag("LevelController").GetComponent<waveSpawner>().WaveNumberForUi;

        if (timer > 0)
            timer -= Time.deltaTime;
        else
        {
gameObject.SetActive(false);
             easeout = true;
            timer = 1.5f;
        }


        if (timer < 0.5f && easeout == true)
        {
            easeout = false;
            Tween.LocalScale(gameObject.transform, Vector3.one, Vector3.zero, 0.2f, 0, Tween.EaseOut);
        }
    }
}
