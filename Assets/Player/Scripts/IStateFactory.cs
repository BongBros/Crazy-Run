public interface IStateFactory
{
    JumpingMovementState createJumpingState();
    RunningMovementState createRunningState();
}