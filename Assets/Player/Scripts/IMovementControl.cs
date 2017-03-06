using UnityEngine;

public interface IMovementControl
{
    void SetMovementVector(Vector2 vector);
    Vector2 GetMovementVector();
    void AddForce(Vector2 vector);
    void SetConstantDownForce(float force);
}