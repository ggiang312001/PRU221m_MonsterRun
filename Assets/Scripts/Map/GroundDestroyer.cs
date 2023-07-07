using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Ground1") || collision.gameObject.CompareTag("Ground2") || collision.gameObject.CompareTag("Ground3") || collision.gameObject.CompareTag("Ground4"))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
