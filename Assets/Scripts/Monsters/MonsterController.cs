using Assets.Scripts.ObjectSave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private GameObject Player;
    HUD hud;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] p = GameObject.FindGameObjectsWithTag("Player");
        Player = p[0];
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.gameObject.active == true)
        {
            float distance = Vector3.Distance(transform.position, Player.transform.position);
            if (distance < 15f)
            {
                transform.position = Vector3.left * GameManage.Instance.speed * 1.1f * Time.deltaTime + transform.position;
            }
            else
            {
                transform.position = Vector3.left * GameManage.Instance.speed * Time.deltaTime + transform.position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject audio = GameObject.FindGameObjectWithTag("audio");
            Audio audio_manager = audio.GetComponent<Audio>();
            if (PlayerController.isLand == false)
            {
                audio_manager.PlayCollider();
                gameObject.SetActive(false);
            }
            else
            {
               
                audio_manager.PlayCollider();
                hud.ReduceHealth();
            }

        }
        if (collision.gameObject.CompareTag("Shield"))
        {
            ShieldActive.Instance.ShieldCount -= 1;
            gameObject.SetActive(false);
        }
    }
}
