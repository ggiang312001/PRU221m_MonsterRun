using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletController : MonoBehaviour
{
    private WizardExplosionPool WizardExplosionPool;
    HUD hud;
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        WizardExplosionPool = FindObjectOfType<WizardExplosionPool>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.left * GameManage.speed * 2.5f * Time.deltaTime + transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hud.ReduceHealth();
            transform.gameObject.SetActive(false);
            List<GameObject> listFighters = WizardExplosionPool.pool;
            GameObject explosion = WizardExplosionPool.GetObject(); // Lấy trap từ pool
            explosion.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, 0); // Set vị trí của trap
            explosion.SetActive(true);
        }
    }
}
