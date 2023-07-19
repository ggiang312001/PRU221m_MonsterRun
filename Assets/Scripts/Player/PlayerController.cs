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
        if (ScreenUtils.ScreenBottom > transform.position.y)
        {
            hud.Dead();
           
            //gameObject.SetActive(false);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Ground2") || collision.gameObject.CompareTag("Ground3"))
        {
            if (transform.position.y >= collision.gameObject.transform.GetChild(0).gameObject.transform.position.y)
            {
                canJump = true;
                isLand = true;
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
