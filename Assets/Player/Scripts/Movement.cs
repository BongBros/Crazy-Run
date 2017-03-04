using System;
using UnityEngine;


public class Movement : MonoBehaviour, IMovementControl, IStateContext //TODO IMovementEffects - particles from sliding etc...
{
    private Rigidbody m_Rigidbody;

    private IMovementState m_CurrentState;

    private CollisionCheck m_CollisionCheck;
    
    private StateFactory m_StateFactory;

    private bool m_Grounded;

    private void Start()
    {

    }

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_CollisionCheck = GetComponent<CollisionCheck>();
        m_StateFactory = GetComponent<StateFactory>();
        this.m_CurrentState = m_StateFactory.createRunningState();

        m_Grounded = m_CollisionCheck.isGrounded();
    }

    private void FixedUpdate()
    {

    }

    public void switchState(IMovementState state)
    {
        this.m_CurrentState = state;
    }





    public void ProcessInput(PlayerInput input)
    {
        m_CurrentState.ProcessInput(input);
    }







    public Vector2 getMovementVector()
    {
        return m_Rigidbody.velocity;
    }

    public void setMovementVector(Vector2 vector)
    {
        m_Rigidbody.velocity = vector;
    }

    public void AddForce(Vector2 vector)
    {
        m_Rigidbody.AddForce(vector);
    }

}

