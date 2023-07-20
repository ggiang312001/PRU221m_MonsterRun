using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldActive : MonoBehaviour
{
    private static ShieldActive instance = null;
    public int ShieldCount = 5;
    public static ShieldActive Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ShieldActive();
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ShieldCount <= 0)
        {
            gameObject.SetActive(false);    
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Bullet"))
        //{
        //    ShieldCount -= 1;
        //    collision.gameObject.SetActive(false);
        //    GameObject explosion = BulletController.Instance.WizardExplosionPool.GetObject(); 
        //    explosion.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, 0); 
        //    explosion.SetActive(true);
        //}
    }
}
