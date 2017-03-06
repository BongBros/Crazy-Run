using System;

public class MachineContext : IMachineContext
{
    private IStateContext stateContext;
    private IMovementControl movementControl;
    private Movement movement;
    private IStateFactory stateFactory;
    private IMovementAnimation animator;

    public MachineContext(IStateContext stateContext, IMovementControl movementControl, IStateFactory stateFactory, IMovementAnimation animator)
    {
        this.stateFactory = stateFactory;
        this.stateContext = stateContext;
        this.movementControl = movementControl;
        this.animator = animator;
    }

    public IStateContext getStateContext()
    {
        return stateContext;
    }

    public IMovementControl getMovementControl()
    {
        return movementControl;
    }

    public IStateFactory getStateFactory()
    {
        return stateFactory;
    }

    public IMovementAnimation getAnimator()
    {
        return animator;
    }
}