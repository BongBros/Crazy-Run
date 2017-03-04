using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class StateFactory : MonoBehaviour, IStateFactory
{
    [SerializeField]
    private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis
    [SerializeField]
    private float m_JumpForce = 400f;                  // Amount of force added when the player jumps
    private MachineContext m_MachineContext;

    private void Start()
    {
        Movement movement = GetComponent<Movement>(); //TODO inject..
        this.m_MachineContext = new MachineContext(movement, movement, this);
    }
    
    public JumpingMovementState createJumpingState()
    {
        return new JumpingMovementState(m_MachineContext, m_JumpForce);
    }

    public RunningMovementState createRunningState()
    {
        return new RunningMovementState(m_MachineContext, m_MaxSpeed);
    }
}
