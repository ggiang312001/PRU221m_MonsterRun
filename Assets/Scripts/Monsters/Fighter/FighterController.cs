using Assets.Scripts.Monsters.Fighter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterController : MonoBehaviour
{
    public Animator animator;

    private float attackRange = 1f;
    private GameObject Player;
    private FighterState currentState;
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] p = GameObject.FindGameObjectsWithTag("Player");
        Player = p[0];
        animator = GetComponent<Animator>();
        currentState = new MonterRunState(this);
        currentState.EnterState();
    }

    // Update is called once per frame
    void Update()
    {
        //currentState.UpdateState();
        if (transform.gameObject.active == true)
        {
            float distance = Vector3.Distance(transform.position, Player.transform.position);
            if (distance < attackRange)
            {
                currentState.UpdateState();
            }
        }
        
    }

    public void ChangeState(FighterState newState)
    {
        currentState.ExitState();
        currentState = newState;
        currentState.EnterState();
    }
}
