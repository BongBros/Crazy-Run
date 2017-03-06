using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningMovementState : MovementStateAdapter
{
    private float maxSpeed;
    private float acceleration;

    public RunningMovementState(IMachineContext machineContext, float maxSpeed, float acceleration) : base(machineContext)
    {
        this.maxSpeed = maxSpeed;
        this.acceleration = acceleration;
    }

    public override void ProcessInput(PlayerInput input)
    {
        
        Vector2 currentVector = control.GetMovementVector();

        float currentSpeed = currentVector.x;
        float newSpeed = (currentSpeed + input.horizontal * acceleration);


        if (Mathf.Abs(newSpeed) > maxSpeed)
        {
            newSpeed = Math.Sign(newSpeed) * maxSpeed;
        }
                
        control.SetMovementVector(new Vector2(newSpeed, currentVector.y));

        if (input.jump)
        {
            context.SwitchState(factory.createJumpingState());
        }

        if (input.slide)
        {
            context.SwitchState(factory.createSlidingState());
        }
    }

    public override void LostGround()
    {
        context.SwitchState(factory.createFallingState());
    }
}
