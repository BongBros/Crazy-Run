public interface IMachineContext
{
    IMovementControl getMovementControl();
    IStateContext getStateContext();
    IStateFactory getStateFactory();
    IMovementAnimation getAnimator();
}