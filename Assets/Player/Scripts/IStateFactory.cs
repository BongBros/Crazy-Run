public interface IStateFactory
{
    IMovementState createJumpingState();
    IMovementState createRunningState();
    IMovementState createFallingState();
    IMovementState createSlidingState();
}