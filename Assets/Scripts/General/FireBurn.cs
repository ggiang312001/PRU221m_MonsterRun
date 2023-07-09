using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBurn : MonoBehaviour
{
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.activeSelf == true)
        {
            time += Time.deltaTime;
            if(time >= 2)
            {
                gameObject.SetActive(false);
                time = 0;
            }
        }
    }
}
