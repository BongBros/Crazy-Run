using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractMovementState : IMovementState {
    protected IStateContext context;
    protected IMovementControl control;
    protected IStateFactory factory;

    public AbstractMovementState(IMachineContext machineContext)
    {
        this.control = machineContext.getMovementControl();
        this.context = machineContext.getStateContext();
        this.factory = machineContext.getStateFactory();
    }

    public virtual void Grounded()
    {

    }

    public virtual void LostGround()
    {

    }

    public virtual void ProcessInput(PlayerInput input)
    {

    }

}
