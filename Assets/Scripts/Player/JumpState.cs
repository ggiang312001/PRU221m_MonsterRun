using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class JumpSate : PlayerState
{

    public JumpSate(PlayerController player) : base(player)
    {
    }

    public override void EnterState()
    {
        player.jumpCount++;
        PlayerController.isLand = false;
        player.anm.SetBool("isRun", false);
        player.anm.SetBool("isJump", true);
        player.rgd2d.velocity = Vector3.up * 7f;
    }

    public override void UpdateState()
    {
        if (Input.GetMouseButtonUp(0) && player.canJump)
        {
            EnterState();
        }

        if (PlayerController.isLand)
        {
            player.ChangeState(new RunState(player));
            player.jumpCount = 0;
        }
    }


}
