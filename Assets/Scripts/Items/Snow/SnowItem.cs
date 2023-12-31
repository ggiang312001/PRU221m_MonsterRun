using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowItem : ItemController
{
    public static float speedBeforeSnow;
    float time;
    public static int numberSnowItem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        transform.position = Vector3.left * GameManage.Instance.speed * Time.deltaTime + transform.position;
    }


    protected override void InteractWithPlayer()
    {
        numberSnowItem++;
        gameObject.SetActive(false);
        if (numberSnowItem <= 1)
        {
            speedBeforeSnow = GameManage.Instance.speed;
            GameManage.Instance.isSnow = true;
            GameManage.Instance.speed -= 1f;
        }
    }
}
