using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class FallingMovementState : MovementStateAdapter
{

    private float downForce;

    public FallingMovementState(IMachineContext machineContext, float downForce) : base(machineContext)
    {
        this.downForce = downForce;
    }

    public override void OnEnter()
    {
        control.SetConstantDownForce(downForce);
    }

    public override void ProcessInput(PlayerInput input)
    {
        if (input.jump)
        {
            context.SwitchState(factory.createJumpingState());
        }
    }

    public override void Grounded()
    {
        context.SwitchState(factory.createRunningState());
    }

    public override void OnExit()
    {
        control.SetConstantDownForce(0);
    }

}

