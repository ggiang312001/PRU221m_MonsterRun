using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    Timer spawningTime;
    void Start()
    {
        spawningTime = gameObject.AddComponent<Timer>();
        spawningTime.Duration = 0.5f;
        spawningTime.Run();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.left * GameManage.speed * Time.deltaTime + transform.position;
        if (spawningTime.Finished)
        {
            Destroy(gameObject);
        }
    }
}
