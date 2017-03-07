using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public Transform respawnable;
    public Rigidbody respawnableRigidbody;
    public Transform spawnPoint;
    public int minY;
	// Use this for initialization
	void Start () {
        respawnable.position = spawnPoint.position;
        respawnableRigidbody = respawnable.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		if (respawnable.position.y < minY)
        {
            respawnable.position = spawnPoint.position;
            respawnable.position = spawnPoint.position;
            respawnableRigidbody.velocity = new Vector3(0f, 0f, 0f);
        }
	}
}
