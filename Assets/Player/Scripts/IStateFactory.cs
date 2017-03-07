public interface IStateFactory
{
    IMovementState createJumpingFromGroundState();
    IMovementState createRunningState();
    IMovementState createFallingState();
    IMovementState createSlidingState();
    IMovementState createFallingJumpableState();
    IMovementState createJumpingFromAirState();
}