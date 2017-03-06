using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class StateFactory : MonoBehaviour, IStateFactory
{
    [SerializeField]
    private int downForce; // causes player to fall faster
    [SerializeField]
    private int slideDownForce; // causes player to slide faster

    [SerializeField]
    private float runMaxSpeed; // The fastest the player can run in the x axis
    [SerializeField]
    private float runAcceleration; // The fastest the player can run in the x axis

    [SerializeField]
    private float jumpForceInitial; // Amount of force added when the player initiates a jumps
    [SerializeField]
    private float jumpForceSustain; // Amount of force added when the player holds a jump
    [SerializeField]
    private int jumpSustainLength; // How long a player can hold a jump
                
    private MachineContext m_MachineContext;
    private Movement movement;

    private void Awake()
    {
        this.movement = GetComponent<Movement>(); //TODO inject..
        
    }
    
    public IMovementState createJumpingState()
    {
        return new JumpingMovementState(GetMachineContext(), jumpForceInitial, jumpForceSustain, jumpSustainLength, downForce);
    }

    public IMovementState createRunningState()
    {
        return new RunningMovementState(GetMachineContext(), runMaxSpeed, runAcceleration);
    }

    public IMovementState createFallingState()
    {
        return new FallingMovementState(GetMachineContext(), downForce);
    }

    public IMovementState createSlidingState()
    {
        return new SlidingMovementState(GetMachineContext(), slideDownForce);
    }
    
    private IMachineContext GetMachineContext()
    {
        return this.m_MachineContext = new MachineContext(movement, movement, this, movement.getAnimator());
    }

}
