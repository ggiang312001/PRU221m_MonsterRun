using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowItem : ItemController
{
    protected override void InteractWithPlayer()
    {
        GameManage.speed -= 2;
        GeneratorItem.SnowObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
