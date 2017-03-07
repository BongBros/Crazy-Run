using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class JumpingMovementState : MovementStateAdapter
{
    private float jumpForceInitial;
    private float jumpForceSustain;
    private int jumpForceSustainFrames;

    private int frameCounter = 0;
    private float downForce;

    public JumpingMovementState(IMachineContext machineContext, float jumpForceInitial, float jumpForceSustain, int jumpForceSustainFrames, float downForce) : base(machineContext)
    {
        this.jumpForceInitial = jumpForceInitial;
        this.jumpForceSustain = jumpForceSustain;
        this.jumpForceSustainFrames = jumpForceSustainFrames;
        this.downForce = downForce;
    }

    public override void OnEnter()
    {
        //control.SetMovementVector(new Vector2(control.GetMovementVector().x, 0f));
        control.SetConstantDownForce(downForce);
        control.AddForce(new Vector2(0f, jumpForceInitial));
        animator.Jump();

    }

    public override void ProcessInput(PlayerInput input)
    {
        if (input.jump) //add more force when held longer
        {
            if (frameCounter < jumpForceSustainFrames)
            {
                frameCounter++;
                if (control.GetMovementVector().y < 0)
                {
                    Debug.LogError("Falling down but still applying Jump Sustain Force");
                }
                
                control.AddForce(new Vector2(0f, jumpForceSustain));
            }
        } else
        {
            context.SwitchState(factory.createFallingState());
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

