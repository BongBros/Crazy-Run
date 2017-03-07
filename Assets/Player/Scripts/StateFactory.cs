using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class StateFactory : MonoBehaviour, IStateFactory
{

    //RUNNING
    // if acceleration causes the X vector coordinate to be larger than runMaxSpeed then it is set to runMaxSpeed
    // the fastest the player can run in the x axis
    [SerializeField]
    private float runMaxSpeed;
    
    //RUNNING
    // adds runAcceleration to X vector coordinate on every frame when the rigidbody is moving in the direction intended by the player (rigidbody goes right and player holds right)
    // how fast the player reaches max speed (linear acceleration)
    [SerializeField]
    private float runAcceleration;

    //RUNNING
    // subtracts runResponsivenes from X vector coordinate on every frame when the rigidbody is not moving in the direction intended by the player (rigidbody goes right and player holds left or isn't holding any direction)
    // how fast the player stops (may reduce the sliding effect) and changes direction
    [SerializeField]
    private float runResponsiveness;

    //RUNNING
    // if the X vector coordinate is larger than runMaxSpeed then runDeceleration is subtracted on every frame until the X vector is equal to runMaxSpeed
    // how fast the player slows down to max running speed (i.e. is sliding faster than max speed and starts to run)
    [SerializeField]
    private float runDeceleration;

    //JUMPING
    // instant force added along Y vector coordinate at the beginning of the jump
    // how high the player can jump by pressing the jump button
    [SerializeField]
    private float jumpForceInitial;

    //JUMPING
    // force added along Y vector coordinate on every frame when still holding the jump button
    // how much higher the player can jump by holding the jump button (works like a jetpack)
    [SerializeField]
    private float jumpForceSustain;

    //JUMPING
    // number of frames that jump sustain takes effect for (i.e. when jumpSustainLength frames have passed since initiating the jump but the player still holds down the button it won't take effect)
    // how long is the additional jump force applied
    [SerializeField]
    private int jumpSustainLength;

    //JUMPING
    // resets vector Y coordinate to 0 right before initiating jump
    // should the player jump with the same height even when moving down (e.g. falling down and doing a double jump)
    [SerializeField]
    private bool jumpIgnorePreviousVelocity;

    //JUMPING and FALLING
    // constant downward force(0, -downForce, 0) applied on every frame
    // causes player to fall faster when increased but also to jump lower; combined with increasing of jump force the player may jump with the same height but going faster up and down
    [SerializeField]
    private int inAirDownForce;

    //SLIDING
    // constant downward force (0, -slideDownForce, 0) applied on every frame
    // causes player to slide faster on steeper slopes, but might be slower on narrower slopes (depens on sliding friction though)
    [SerializeField]
    private int slideDownForce;

    private MachineContext m_MachineContext;
    private Movement movement;

    private void Awake()
    {
        this.movement = GetComponent<Movement>(); //TODO inject..
        
    }
    
    public IMovementState createJumpingFromGroundState()
    {
        return new JumpingFromGroundMovementState(GetMachineContext(), jumpForceInitial, jumpForceSustain, jumpSustainLength, inAirDownForce, jumpIgnorePreviousVelocity);
    }

    public IMovementState createRunningState()
    {
        return new RunningMovementState(GetMachineContext(), runMaxSpeed, runAcceleration, runDeceleration, runResponsiveness);
    }

    public IMovementState createFallingState()
    {
        return new FallingMovementState(GetMachineContext(), inAirDownForce);
    }

    public IMovementState createSlidingState()
    {
        return new SlidingMovementState(GetMachineContext(), slideDownForce);
    }
    
    private IMachineContext GetMachineContext()
    {
        return this.m_MachineContext = new MachineContext(movement, movement, this, movement.getAnimator());
    }

    public IMovementState createFallingJumpableState()
    {
        return new FallingJumpableMovementState(GetMachineContext(), inAirDownForce);
    }

    public IMovementState createJumpingFromAirState()
    {
        return new JumpingFromAirMovementState(GetMachineContext(), jumpForceInitial, jumpForceSustain, jumpSustainLength, inAirDownForce, jumpIgnorePreviousVelocity);

    }
}
