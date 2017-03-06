using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementState {

    void OnEnter();
    void OnExit();

    void ProcessInput(PlayerInput input);
    void Grounded();
    void LostGround();
}
