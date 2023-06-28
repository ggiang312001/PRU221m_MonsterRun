using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public static float speedGround = 3;
    public static float speedTrap = 3;
    public static float speedItem = 3;
    float runTime;
    float changeSpeedGroundTime;
    // Start is called before the first frame update
    void Start()
    {
        runTime = 0;
        changeSpeedGroundTime = 15;
    }

    // Update is called once per frame
    void Update()
    {
        runTime += Time.deltaTime;
        if (runTime >= changeSpeedGroundTime)
        {
            speedGround += 0.5f;
            speedTrap += 0.5f;
            speedItem += 0.5f;
            changeSpeedGroundTime += 15;
        }
    }
}
