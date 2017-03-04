using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class JumpingMovementState : AbstractMovementState
{
    private float m_JumpForce;
    public JumpingMovementState(IMachineContext machineContext, float jumpForce) : base(machineContext)
    {
        m_JumpForce = jumpForce;
    }

    public override void ProcessInput(PlayerInput input)
    {
        if (input.jump) //TODO more force when held longer
        {
            // Otherwise character jumps lower when moving down (e.g. on a ramp)
            control.setMovementVector(new Vector2(control.getMovementVector().x, 0f));
            control.AddForce(new Vector2(0f, m_JumpForce));
        }
    }

    public override void Grounded()
    {
        context.switchState(factory.createRunningState());
    }

}

