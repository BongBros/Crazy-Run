using System;
using UnityEngine;


public class Movement : MonoBehaviour, IMovementState, IMovementControl, IStateContext //TODO IMovementEffects - particles from sliding etc...
{

    [SerializeField]
    private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis
    [SerializeField]
    private float m_JumpForce = 400f;                  // Amount of force added when the player jumps
    [SerializeField]
    private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded
    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded
    private Transform m_CeilingCheck;   // A position marking where to check for ceilings
    const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
    private Rigidbody m_Rigidbody;

    private void Awake()
    {

        // Setting up references.
        m_GroundCheck = transform.Find("GroundCheck");
        m_CeilingCheck = transform.Find("CeilingCheck");
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    private void FixedUpdate()
    {
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider[] colliders = Physics.OverlapSphere(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                m_Grounded = true;
        }
    }

    public Vector2 getMovementVector()
    {
        return m_Rigidbody.velocity;
    }

    public void setMovementVector(Vector2 vector)
    {
        m_Rigidbody.velocity = vector;
    }

    public void Move(float move, bool slide, bool jump)
    {

        TriggerSliding(slide);

        //only control the player if on ground and not sliding
        if (m_Grounded && !m_Sliding)
        {

            // Move the character
            m_Rigidbody.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody.velocity.y);

        }

        TriggerJump(jump);
    }

    private void TriggerSliding(bool slide)
    {
        if (!slide && m_Sliding)
        {
            // If the character has a ceiling preventing them from standing up, keep them sliding
            if (!Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                SetSliding(false);
            }
        }

        if (slide && !m_Sliding)
        {
            // Start sliding only when on ground
            if (m_Grounded)
            {
                //TODO: Add force here for extra push when slide is initiated
                SetSliding(true);
            }
        }
    }

    private void SetSliding(bool slide)
    {
        m_Sliding = slide;
    }

    private void TriggerJump(bool jump)
    {
        // If the player should jump...
        if (m_Grounded && jump)
        {
            // Add a vertical force to the player.
            m_Grounded = false;

            // Otherwise character jumps lower when moving down (e.g. on a ramp)
            m_Rigidbody.velocity = new Vector2(m_Rigidbody.velocity.x, 0f);

            m_Rigidbody.AddForce(new Vector2(0f, m_JumpForce));
        }
    }

    public void processInput(PlayerInput input)
    {
        currentState.processInput(input);
    }
}

