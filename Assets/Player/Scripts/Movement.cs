using System;
using UnityEngine;

//TODO
//Fix/tweak:
// * when a player jumps but does not leave the ground (e.g. jumps reeeeaaaaally low and ground collision is always active) he freezes in jumping state
// * before jumping Y velocity is reset so that jump height is the same no matter the current motion direction - this might be a cool feature though but right now causes the above issue if jump is held for the whole duration (player jumps right after landing)
// * delta time https://unity3d.com/learn/tutorials/topics/scripting/delta-time
public class Movement : MonoBehaviour, IMovementControl, IStateContext //TODO IMovementEffects - particles from sliding etc...
{
    private Rigidbody m_Rigidbody;

    private IMovementState m_CurrentState;

    private CollisionCheck m_CollisionCheck;
    
    private IStateFactory m_StateFactory;

    private IMovementAnimation animator;

    private bool m_Grounded;
    private ConstantForce constForce;

    private void Start()
    {
        m_Grounded = m_CollisionCheck.isGrounded();
    }

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        animator = new MovementAnimation(transform.FindChild("Model"));
        m_CollisionCheck = GetComponent<CollisionCheck>();
        m_StateFactory = GetComponent<IStateFactory>();
        this.constForce = GetComponent<ConstantForce>();
        this.m_CurrentState = m_StateFactory.createRunningState();

    }

    public IMovementAnimation getAnimator()
    {
        return animator;
    }

    private void FixedUpdate()
    {
        checkGround();
    }

    private void checkGround()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = m_CollisionCheck.isGrounded();
        if (wasGrounded && !m_Grounded)
        {
            m_CurrentState.LostGround();
        }
        if (!wasGrounded && m_Grounded)
        {
            m_CurrentState.Grounded();
        }
    }

    public void SwitchState(IMovementState state)
    {
        Debug.Log("State change: " + state.ToString(), this);
        this.m_CurrentState.OnExit();
        this.m_CurrentState = state;
        this.animator.Default();
        this.m_CurrentState.OnEnter();
    }
    
    public void ProcessInput(PlayerInput input)
    {
        m_CurrentState.ProcessInput(input);
    }
    
    public Vector2 GetMovementVector()
    {
        return m_Rigidbody.velocity;
    }

    public void SetMovementVector(Vector2 vector)
    {
        m_Rigidbody.velocity = vector;
    }

    public void AddForce(Vector2 vector)
    {
        m_Rigidbody.AddForce(vector);
    }

    public void SetConstantDownForce(float force)
    {
        this.constForce.force = new Vector2(0, -force);
    }


}

