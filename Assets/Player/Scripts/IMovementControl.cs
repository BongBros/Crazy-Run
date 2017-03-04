using UnityEngine;

public interface IMovementControl
{
    void setMovementVector(Vector2 vector);
    Vector2 getMovementVector();
    void AddForce(Vector2 vector);
}