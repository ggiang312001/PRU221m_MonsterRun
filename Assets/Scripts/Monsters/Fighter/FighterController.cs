using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterController : MonoBehaviour
{
    Animator animator;

    private float attackRange = 1f;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] p = GameObject.FindGameObjectsWithTag("Player");
        Player = p[0];
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.gameObject.active == true)
        {
            float distance = Vector3.Distance(transform.position, Player.transform.position);
            if (distance < attackRange)
            {
                animator.SetTrigger("attack");
            }
        }
        
    }
}
