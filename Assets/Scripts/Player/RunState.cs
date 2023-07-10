using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class RunState : PlayerState
{
    private int jumpCount = 0;
    public RunState(PlayerController player) : base(player)
    {
    }
    public override void EnterState()
    {
        player.anm.SetTrigger("Run");
        player.anm.SetBool("isRun", true);
        player.anm.SetBool("isJump", false);
    }

    public override void UpdateState()
    {
        if (Input.GetMouseButtonUp(0) && player.canJump)
        {
            player.ChangeState(new JumpSate(player));  
        }
    }

}
