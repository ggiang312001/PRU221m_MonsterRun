using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : MonoBehaviour
{
    private MineExplosionPool MineExplosionPool;
    // Start is called before the first frame update
    void Start()
    {
        MineExplosionPool = FindObjectOfType<MineExplosionPool>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.gameObject.SetActive(false);
            List<GameObject> listFighters = MineExplosionPool.pool;
            GameObject explosion = MineExplosionPool.GetObject(); // Lấy trap từ pool
            explosion.transform.position = new Vector3(collision.transform.position.x+0.5f, collision.transform.position.y, 0); // Set vị trí của trap
            explosion.SetActive(true);
        }
    }
}
