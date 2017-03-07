using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningMovementState : MovementStateAdapter
{
    private float maxSpeed;
    private float acceleration;
    private float deceleration;
    private float responsiveness;

    public RunningMovementState(IMachineContext machineContext, float maxSpeed, float acceleration, float deceleration, float responsivenes) : base(machineContext)
    {
        this.maxSpeed = maxSpeed;
        this.acceleration = acceleration;
        this.deceleration = deceleration;
        this.responsiveness = responsivenes;
    }

    public override void ProcessInput(PlayerInput input)
    {

        if (input.slide)
        {
            context.SwitchState(factory.createSlidingState());
            return;
        }

        if (input.jump)
        {
            context.SwitchState(factory.createJumpingState());
            return;
        }

        Vector2 currentVector = control.GetMovementVector();

        float currentSpeed = currentVector.x;
        float tempSpeed = currentSpeed;
        //first decelerate up to max speed if needed
        if (Mathf.Abs(currentSpeed) > maxSpeed)
        {
            tempSpeed = (currentSpeed - Mathf.Sign(currentSpeed) * deceleration);

            //if subtracted too much, top to max speed; the second condition is for very large deceleration values (e.g. current = 40; max = 30; decel = 100; abs(max - decel) = 60 > max)
            if (Mathf.Abs(tempSpeed) < maxSpeed || Mathf.Sign(tempSpeed) != Mathf.Sign(currentSpeed))
            {
                tempSpeed = Math.Sign(currentSpeed) * maxSpeed;
            }
        }

        if (tempSpeed >= maxSpeed)
        {
            //when at max speed apply acceleration only in opposite direction
            if (Math.Sign(tempSpeed) == -Math.Sign(input.horizontal))
            {
                tempSpeed = (tempSpeed + input.horizontal * acceleration);
            }
        } else {
            //when not at max speed apply acceleration to any direction but do not cross max speed
            tempSpeed = (tempSpeed + input.horizontal * acceleration);
            //if added too much, top to max speed
            if (Mathf.Abs(tempSpeed) > maxSpeed)
            {
                tempSpeed = Math.Sign(tempSpeed) * maxSpeed;
            }
        }

        if(Math.Sign(tempSpeed) != Math.Sign(input.horizontal)) {
            //apply additional responsivenes force when player intentions are different that current movement vector regardless of speed
            float responsivenessSpeed = tempSpeed - Math.Sign(tempSpeed) * responsiveness;
            //but do not allow overflow
            if (Mathf.Sign(responsivenessSpeed) != Mathf.Sign(tempSpeed))
            {
                responsivenessSpeed = 0;
            }
            tempSpeed = responsivenessSpeed;
        }
        
        control.SetMovementVector(new Vector2(tempSpeed, currentVector.y));

        float animationSkew = input.horizontal;
        //float animationSkew = Math.Min(tempSpeed / maxSpeed, 1);
        animator.Run(animationSkew);
    }

    public override void LostGround()
    {
        context.SwitchState(factory.createFallingState());
    }
}
