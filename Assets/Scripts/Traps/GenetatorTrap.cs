using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorTrap : MonoBehaviour
{

    List<GameObject> listTrap;
    // Start is called before the first frame update
    void Start()
    {

    }
    float timeSpawner = 5;
    float count = 0;
    float timer = 0;
    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if(count >= 120 && (int)count % 120 == 0)
        {
            if(timeSpawner > 1.5)
            {
                timeSpawner -= 0.5f;
            }
            count = 0;
        }
        timer += Time.deltaTime;
        if(timer == timeSpawner)
        {
            SpawnTrap();
            timer = 0;
        }
        
    }

    private void SpawnTrap()
    {
        int radom = UnityEngine.Random.Range(1,3);
    }
}
