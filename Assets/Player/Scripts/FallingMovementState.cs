using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class FallingMovementState : FallingJumpableMovementState
{ 

    public FallingMovementState(IMachineContext machineContext, float downForce) : base(machineContext, downForce)
    {

    }

    public override void ProcessInput(PlayerInput input)
    {

    }

}

