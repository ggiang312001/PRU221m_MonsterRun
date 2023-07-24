using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornTrap : TrapController
{
    protected override void InteractWithPlayer()
    {
        AudioManager.Play(AudioClipName.Collider);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.left * GameManage.Instance.speed * Time.deltaTime + transform.position;
    }
}
