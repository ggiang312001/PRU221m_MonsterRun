using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplosionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    float timer = 0;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (transform.gameObject.active == true)
        {
            timer += Time.deltaTime;
            if (timer >= 0.5f)
            {
                transform.gameObject.SetActive(false);
                timer = 0;
            }
        }
    }
}
