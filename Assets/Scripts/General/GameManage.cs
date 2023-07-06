using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public static float speed = 3;
    public static bool isSnow = false;
    float runTime;

    float changeSpeedTime;
    // Start is called before the first frame update
    void Start()
    {
        runTime = 0;
        changeSpeedTime = 15;
    }

    // Update is called once per frame
    void Update()
    {
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
