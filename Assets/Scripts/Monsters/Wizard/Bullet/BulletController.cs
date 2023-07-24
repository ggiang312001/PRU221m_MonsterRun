using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletController : MonoBehaviour
{
    private WizardExplosionPool WizardExplosionPool;
    HUD hud;
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        WizardExplosionPool = FindObjectOfType<WizardExplosionPool>();
        rb2D = GetComponent<Rigidbody2D>();
        if (rb2D == null)
            rb2D = gameObject.AddComponent<Rigidbody2D>();

        // Disable gravity for the Rigidbody2D
        rb2D.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.left * GameManage.Instance.speed * 2.5f * Time.deltaTime + transform.position;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.Play(AudioClipName.Collider);
            hud.ReduceHealth();
            transform.gameObject.SetActive(false);
            List<GameObject> listFighters = WizardExplosionPool.pool;
            GameObject explosion = WizardExplosionPool.GetObject(); // Lấy trap từ pool
            explosion.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, 0); // Set vị trí của trap
            explosion.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Shield"))
        {
            AudioManager.Play(AudioClipName.Collider);
            ShieldActive.Instance.ShieldCount -= 1;
            gameObject.SetActive(false);
            GameObject explosion = WizardExplosionPool.GetObject(); // Lấy trap từ pool
            explosion.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, 0); // Set vị trí của trap
            explosion.SetActive(true);
        }
    }
}

