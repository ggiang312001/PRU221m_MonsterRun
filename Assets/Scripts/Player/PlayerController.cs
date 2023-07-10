using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rgd2d;
    HUD hud;
    float runSpeed;
    public int jumpCount = 0;
    //public float gravityForce = 9.8f;
    public bool canJump = true;
    public static bool isLand = false;
    public Animator anm;


    private PlayerState currentState;
    // Start is called before the first frame update
    void Start()
    {
        runSpeed = 0;
        rgd2d = GetComponent<Rigidbody2D>();
        anm= GetComponent<Animator>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        currentState = new IdleState(this);
        currentState.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState();
        if (jumpCount == 2)
        {
            canJump = false;
        }

        //transform.position = Vector3.right * runSpeed * Time.deltaTime + transform.position;
        //if(Input.GetMouseButtonUp(0) && canJump)
        //{
        //    rgd2d.velocity = Vector3.up * 7f;
        //    anm.SetBool("isJump", true);
        //    anm.SetBool("isRun", false);
        //    //anm.SetTrigger("Jump");
        //    //anm.SetBool("isRun", false);
        //    jumpCount++;
        //}
        if (ScreenUtils.ScreenBottom > transform.position.y)
        {
            hud.Dead();
            gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (transform.position.y >= collision.gameObject.transform.GetChild(0).gameObject.transform.position.y)
            {
                //anm.SetBool("isRun", true);
                //anm.SetBool("isJump", false);
                canJump = true;
                isLand = true;
                //anm.SetBool("isJump", false);
                //anm.SetBool("isRun", true);
                //anm.SetTrigger("drop");
                //jumpCount = 0;
            }
      
        }
    }

    public void ChangeState(PlayerState newState)
    {
        currentState.ExitState();
        currentState = newState;
        currentState.EnterState();
    }
}
