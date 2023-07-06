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

        if(GameManage.isSnow == true)
        {
            time += Time.deltaTime;
            if(numberSnowItem > 1)
            {
                time = 0;
                numberSnowItem = 1;
            }
            if (time >= 10)
            {
                GameManage.speed = speedBeforeSnow;
                GameManage.isSnow= false;
                time = 0;
                numberSnowItem = 0;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("WoodBox"))
        {
            canJump = true;
            //anm.SetBool("isJump", false);
            //anm.SetBool("isRun", true);
            //anm.SetTrigger("drop");
            jumpCount = 0;
        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            //Time.timeScale = 0;
            //anm.SetTrigger("dead");
            isDead = true;
            //timer.Duration = 0.5f;
            //timer.Run();
           
            hud.ReduceHealth();
        }
        if (collision.gameObject.CompareTag("HeartItem"))
        {
            collision.gameObject.SetActive(false);
            if (hud.GetHealth() < 5)
            {
                hud.IncreaseHealth();
            }
        }
        if (collision.gameObject.CompareTag("SnowItem"))
        {
            numberSnowItem++;
            collision.gameObject.SetActive(false);
            if (numberSnowItem <= 1){
                speedBeforeSnow = GameManage.speed;
                GameManage.isSnow = true;
                GameManage.speed -= 2f;
            }
        }
    }
}
