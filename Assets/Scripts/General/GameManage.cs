using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public static float speed = 3;

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
            speed += 0.5f;
            changeSpeedGroundTime += 15;
        }
    }
}
