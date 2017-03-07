using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class JumpingFromAirMovementState : JumpingFromGroundMovementState
{

    public JumpingFromAirMovementState(IMachineContext machineContext, float jumpForceInitial, float jumpForceSustain, int jumpForceSustainFrames, float downForce, bool ignorePreviousVelocity) : base(machineContext, jumpForceInitial, jumpForceSustain, jumpForceSustainFrames, downForce, ignorePreviousVelocity)
    {
    }

    protected override void GoToNextState()
    {
        context.SwitchState(factory.createFallingState());
    }

}

