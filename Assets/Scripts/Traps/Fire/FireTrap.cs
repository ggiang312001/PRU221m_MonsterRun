using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : TrapController
{
    protected override void InteractWithPlayer()
    {
        //GameObject audio = GameObject.FindGameObjectWithTag("audio");
        //Audio audio_manager = audio.GetComponent<Audio>();
        //audio_manager.PlayFire();
        AudioManager.Play(AudioClipName.FireDamage);
        GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(true);
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
