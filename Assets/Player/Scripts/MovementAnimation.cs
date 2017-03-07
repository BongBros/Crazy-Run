using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class MovementAnimation : IMovementAnimation
{
    private int maxSkew = 20;

    private Transform transform;

    public MovementAnimation(Transform transform)
    {
        this.transform = transform;
    }

    public void Run(float skew)
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        transform.localPosition = new Vector3(0f, 0f, 0f);
        Quaternion target = Quaternion.Euler(0, 0, -skew * maxSkew);
        transform.rotation = target;
    }

    public void Default()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
        transform.localPosition = new Vector3(0f, 0f, 0f);
        Quaternion target = Quaternion.Euler(0, 0, 0);
        transform.rotation = target;
    }

    public void Jump()
    {

    }

    public void Slide()
    {
        transform.localScale = new Vector3(1f, 0.5f, 1f);
		Vector3 pos = transform.position;
		transform.position = new Vector3(pos.x, pos.y - 0.5f, pos.z);
    }
}
