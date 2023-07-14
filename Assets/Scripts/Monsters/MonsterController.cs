using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    HUD hud;
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.left * GameManage.Instance.speed * 1.1f * Time.deltaTime + transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerController.isLand == false)
            {
                gameObject.SetActive(false);
            }
            else
            {
                hud.ReduceHealth();
            }

        }
    }
}
