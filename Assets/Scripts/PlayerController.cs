using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rgd2d;
    public int runSpeed;
    private int jumpCount = 0;
    private bool canJump = true;
    Animator anm;
    // Start is called before the first frame update
    void Start()
    {
        rgd2d= GetComponent<Rigidbody2D>();
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
            rgd2d.velocity = Vector3.up * 7.5f;
            anm.SetTrigger("jump");
            jumpCount++;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
            jumpCount = 0;
        }
    }
}
