using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingMovementState : MovementStateAdapter
{
    private int slideDownForce;

    public SlidingMovementState(IMachineContext machineContext, int slideDownForce) : base(machineContext)
    {
        this.slideDownForce = slideDownForce;
    }

    public override void OnEnter()
    {
        control.SetConstantDownForce(slideDownForce);
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

    public void onExit()
    {
        control.SetConstantDownForce(0);
    }
}
