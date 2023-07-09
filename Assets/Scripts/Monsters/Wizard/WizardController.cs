using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class WizardController : MonoBehaviour
{
    Animator animator;

    private WizardBulletPool WizardBulletPool;
    private List<GameObject> listBullets;
    private float attackRange = 20f;
    private GameObject Player;
    

    // Start is called before the first frame update
    void Start()
    {
        
        GameObject[] p = GameObject.FindGameObjectsWithTag("Player");
        Player = p[0];
        animator = GetComponent<Animator>();
        WizardBulletPool = FindObjectOfType<WizardBulletPool>();
        listBullets = WizardBulletPool.pool;
    }
    float timer = 0;
    // Update is called once per frame
    void Update()
    {
        
        if (transform.gameObject.active == true)
        {
            timer += Time.deltaTime;
            float distance = Vector3.Distance(transform.position, Player.transform.position);
            if (distance < attackRange && timer >= 2f)
            {
                //animator.SetTrigger("attack");
                //StartCoroutine(Shoot(Player));
                animator.SetTrigger("attack");
                int count = 0;
                foreach (GameObject obj in listBullets)
                {
                    if (obj.active == false)
                    {
                        count++;
                    }
                }
                if (count != 0)
                {
                    GameObject bullet = WizardBulletPool.GetObject(); // Lấy trap từ pool
                    bullet.transform.position = new Vector3(transform.position.x - 0.3f, transform.position.y - 0.2f, 0); // Set vị trí của trap
                    bullet.SetActive(true); // Hiển thị trap lên màn hình
                    count = 0;
                }
                timer = 0;
            }
        }

    }

}
