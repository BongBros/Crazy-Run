using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class MovementAnimation : IMovementAnimation
{
    private Transform transform;

    public MovementAnimation(Transform transform)
    {
        this.transform = transform;
    }

    public void Default()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }

    public void Jump()
    {
        //m_Rigidbody.AddTorque(new Vector3(10f, 10f, 0f));
    }

    public void Slide()
    {
        transform.localScale = new Vector3(1f, 0.5f, 1f);
		Vector3 pos = transform.position;
		//transform.position = new Vector3(pos.x, pos.y - 0.3f, pos.z);
    }
}
