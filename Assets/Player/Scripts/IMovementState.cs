using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementState {

    void processInput(PlayerInput input);

}
