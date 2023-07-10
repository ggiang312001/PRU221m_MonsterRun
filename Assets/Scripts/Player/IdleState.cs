using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    // Start is called before the first frame update
    public IdleState(PlayerController player) : base(player)
    {
    }

    public override void EnterState()
    { 
    }

    public override void UpdateState()
    {
        player.ChangeState(new RunState(player));
    }
}
