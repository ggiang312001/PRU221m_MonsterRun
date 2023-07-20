using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldItem : ItemController
{
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
        GameObject.FindGameObjectWithTag("Player").transform.GetChild(2).gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
