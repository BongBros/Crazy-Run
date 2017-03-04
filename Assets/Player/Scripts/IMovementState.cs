using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementState {

    void ProcessInput(PlayerInput input);
    void Grounded();
    void LostGround();
}
