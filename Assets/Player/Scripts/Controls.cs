using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof(Movement))]
public class Controls : MonoBehaviour
{
    private Movement movement;
    private bool jump;
    
    private void Awake()
    {
        movement = GetComponent<Movement>();
    }
    
    private void Update()
    {
        // Read the jump input in Update so button presses aren't missed.
        if (!jump)
        {
            if (CrossPlatformInputManager.GetButtonDown("Jump")) {
                Debug.Log("Jump initiated", movement);
                jump = true;
            }
        } else
        {
            if (CrossPlatformInputManager.GetButtonUp("Jump"))
            {
                Debug.Log("Jump finished", movement);
                jump = false;
            }
        }


    }


    private void FixedUpdate()
    {
        // Pass all parameters to the character control script.
        PlayerInput playerInput = new PlayerInput();
        playerInput.slide = Input.GetKey(KeyCode.DownArrow);
        playerInput.jump = jump;
        playerInput.horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        movement.ProcessInput(playerInput);
        
    }
}
