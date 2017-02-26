using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    public Transform respawnable;
    public Transform spawnPoint;
    public int minY;
	// Use this for initialization
	void Start () {
        respawnable.position = spawnPoint.position;
    }
	
	// Update is called once per frame
	void Update () {
		if (respawnable.position.y < minY)
        {
            respawnable.position = spawnPoint.position;
        }
	}
}
