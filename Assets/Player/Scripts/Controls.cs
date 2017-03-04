using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof(Movement))]
public class Controls : MonoBehaviour
{
    private Movement m_movement;
    private bool m_Jump;
    
    private void Awake()
    {
        m_movement = GetComponent<Movement>();
    }
    
    private void Update()
    {
        if (!m_Jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
    }


    private void FixedUpdate()
    {
        // Pass all parameters to the character control script.
        PlayerInput playerInput = new PlayerInput();
        playerInput.slide = Input.GetKey(KeyCode.DownArrow);
        playerInput.jump = m_Jump;
        playerInput.horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        m_movement.ProcessInput(playerInput);
        m_Jump = false;
    }
}
