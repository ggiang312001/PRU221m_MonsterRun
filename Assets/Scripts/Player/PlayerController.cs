using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rgd2d;
    public int runSpeed;
    private int jumpCount = 0;
    public float gravityForce = 9.8f;
    private bool canJump = true;
    private bool isDead = false;
    Timer timer;
    Timer runTime;
    Animator anm;
    // Start is called before the first frame update
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        rgd2d = GetComponent<Rigidbody2D>();
        anm= GetComponent<Animator>();
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
        //if(timer.Finished && isDead == true)
        //{
        //    Time.timeScale = 0;
        //    isDead = false;
        //}
        if (ScreenUtils.ScreenBottom > transform.position.y)
        {
            Destroy(gameObject);
            Time.timeScale = 0;
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
        }
    }
}
