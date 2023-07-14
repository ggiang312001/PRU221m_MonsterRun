using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    private static GameManage instance = null;
    public float speed = 3;
    public bool isSnow = false;
    float runTime;
    float time;
    float changeSpeedTime;
    // Start is called before the first frame update

    public static GameManage Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManage();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    void Start()
    {
        runTime = 0;
        changeSpeedTime = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if (isSnow == true)
        {
            time += Time.deltaTime;
            if (SnowItem.numberSnowItem > 1)
            {
                time = 0;
                SnowItem.numberSnowItem = 1;
            }
            if (time >= 10)
            {
                speed = SnowItem.speedBeforeSnow;
                isSnow = false;
                time = 0;
                SnowItem.numberSnowItem = 0;
            }
        }

        if (isSnow == false)
        {
            runTime += Time.deltaTime;
            if (runTime >= changeSpeedTime)
            {
                speed += 0.5f;
                changeSpeedTime += 15;
            }
        } 
        HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        if (hud.GetHealth()==0) { Time.timeScale = 0; }
    }
}
