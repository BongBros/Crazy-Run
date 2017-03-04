using System;

public class MachineContext : IMachineContext
{
    private IStateContext stateContext;
    private IMovementControl movementControl;
    private Movement movement;
    private IStateFactory stateFactory;

    public MachineContext(IStateContext stateContext, IMovementControl movementControl, IStateFactory stateFactory)
    {
        this.stateFactory = stateFactory;
        this.stateContext = stateContext;
        this.movementControl = movementControl;
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
}