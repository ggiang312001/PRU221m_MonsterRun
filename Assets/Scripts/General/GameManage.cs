using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public static float speed = 3;

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
        runTime += Time.deltaTime;
        if (runTime >= changeSpeedTime)
        {
            speed += 0.5f;
            changeSpeedTime += 15;
        }
    }
}
