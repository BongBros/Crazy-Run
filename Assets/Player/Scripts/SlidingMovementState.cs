using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingMovementState : MovementStateAdapter
{

    public SlidingMovementState(IMachineContext machineContext) : base(machineContext)
    {

    }

    public override void OnEnter()
    {
        animator.Slide();
    }

    public override void ProcessInput(PlayerInput input)
    {
        if (input.jump)
        {
            context.SwitchState(factory.createJumpingState());
        }

        if(!input.slide)
        {
            context.SwitchState(factory.createRunningState());
        }
    }

    public override void LostGround()
    {
        context.SwitchState(factory.createFallingState());
    }
}
