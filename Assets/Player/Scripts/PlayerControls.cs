﻿using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof(PlayerMovement))]
public class PlayerControls : MonoBehaviour
{
    private PlayerMovement m_Character;
    private bool m_Jump;


    private void Awake()
    {
        m_Character = GetComponent<PlayerMovement>();
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
        // Read the inputs.
        bool slide = Input.GetKey(KeyCode.DownArrow);
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
        m_Character.Move(h, slide, m_Jump);
        m_Jump = false;
    }
}
