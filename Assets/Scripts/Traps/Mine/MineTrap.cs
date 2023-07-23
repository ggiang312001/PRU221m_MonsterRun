using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineTrap : TrapController
{
    [SerializeField]
    GameObject explosion;
    protected override void InteractWithPlayer()
    {
        GameObject audio = GameObject.FindGameObjectWithTag("audio");
        Audio audio_manager = audio.GetComponent<Audio>();
        audio_manager.PlayColl();
        Instantiate<GameObject>(explosion, gameObject.transform.position, Quaternion.identity);
        GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject.SetActive(true);
        audio_manager.PlayFire();
        gameObject.SetActive(false);
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
