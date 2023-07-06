using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FỉreTrap : TrapController
{
    protected override void InteractWithPlayer()
    {
        GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.left * GameManage.speed * Time.deltaTime + transform.position;
    }
}
