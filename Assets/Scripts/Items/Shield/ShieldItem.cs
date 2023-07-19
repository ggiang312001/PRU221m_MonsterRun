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
        //HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        //gameObject.SetActive(false);
        //if (hud.GetHealth() < 5)
        //{
        //    hud.IncreaseHealth();
        //}
    }
}
