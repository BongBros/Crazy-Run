using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private ParticleSystem flames;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if (playerMovement.isSliding()) {
        //          if(flames.isPaused)
        //          {
        //              flames.Play();
        //          }
        //      } else
        //      {
        //          if (flames.isPlaying)
        //          {
        //              flames.Stop();
        //          }
        //      }
        //      flames.transform.rotation = Quaternion.LookRotation(playerMovement.getVector().normalized);
    }
}
