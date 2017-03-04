using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningMovementState : AbstractMovementState
{
    private float m_MaxSpeed;

    public RunningMovementState(IMachineContext machineContext, float maxSpeed) : base(machineContext)
    {
        m_MaxSpeed = maxSpeed;
    }

    public override void ProcessInput(PlayerInput input)
    {
        Vector2 currentVector = control.getMovementVector();
        control.setMovementVector(new Vector2(input.horizontal * m_MaxSpeed, currentVector.y));

        if (input.jump)
        {
            context.switchState(factory.createJumpingState());
        }
    }
}
