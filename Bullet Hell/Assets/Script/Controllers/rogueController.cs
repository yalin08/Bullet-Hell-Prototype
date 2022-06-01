using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pixelplacement;


public class rogueController : Singleton<rogueController>
{
   public int xp;
   [SerializeField] int levelupxp;
    [SerializeField] Slider xpbar;

    [SerializeField] GameObject selectItemCanvas;
    public bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float toNextLevelUp;
    // Update is called once per frame
    void Update()
    {
        if (xp >= levelupxp && !isDead)
        {
            xp -= levelupxp;
            levelupxp += levelupxp / 2;
            selectItemCanvas.SetActive(true);
        }
      toNextLevelUp = (float)xp / (float)levelupxp;
        xpbar.value = toNextLevelUp;
    }
}
