using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rgd2d;
    HUD hud;
    float runSpeed;
    float speedBeforeSnow;
    private int jumpCount = 0;
    //public float gravityForce = 9.8f;
    private bool canJump = true;
    private bool isDead = false;
    float time;
    Animator anm;
    int numberSnowItem;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        runSpeed = 0;
        speedBeforeSnow = 0;
        numberSnowItem = 0;
        rgd2d = GetComponent<Rigidbody2D>();
        anm= GetComponent<Animator>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpCount == 2)
        {
            canJump= false;
        }
       transform.position = Vector3.right * runSpeed * Time.deltaTime + transform.position;
        if(Input.GetMouseButtonUp(0) && canJump)
        {
            rgd2d.velocity = Vector3.up * 7f;
            //anm.SetBool("isJump",true);
            //anm.SetBool("isRun", false);
            anm.SetTrigger("jump");
            //anm.SetBool("isRun", false);
            jumpCount++;
        }
        if (ScreenUtils.ScreenBottom > transform.position.y)
        {
            hud.Dead();
            Destroy(gameObject);
            Time.timeScale = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (transform.position.y >= collision.gameObject.transform.GetChild(0).gameObject.transform.position.y)
            {
                canJump = true;
                //anm.SetBool("isJump", false);
                //anm.SetBool("isRun", true);
                //anm.SetTrigger("drop");
                jumpCount = 0;
            }
        }
    }
}
