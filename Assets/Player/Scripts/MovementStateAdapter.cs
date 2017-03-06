using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateAdapter : IMovementState {
    protected IStateContext context;
    protected IMovementControl control;
    protected IStateFactory factory;
    protected IMovementAnimation animator;

    public MovementStateAdapter(IMachineContext machineContext)
    {
        this.control = machineContext.getMovementControl();
        this.context = machineContext.getStateContext();
        this.factory = machineContext.getStateFactory();
        this.animator = machineContext.getAnimator();
    }

    public virtual void Grounded()
    {

    }

    public virtual void LostGround()
    {

    }

    public virtual void OnEnter()
    {

    }

    public virtual void OnExit()
    {

    }

    public virtual void ProcessInput(PlayerInput input)
    {

    }

}
