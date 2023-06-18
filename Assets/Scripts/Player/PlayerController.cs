using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public int runSpeed;
    private int jumpCount = 0;
    private bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.right * runSpeed * Time.deltaTime + transform.position;
        if (Input.GetKeyDown("space"))
        {
            rb2d.velocity = Vector3.up * 7.5f;
        }
    }
}
