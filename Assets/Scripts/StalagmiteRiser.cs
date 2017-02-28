using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalagmiteRiser : MonoBehaviour {
    public Transform stalagmite;
    public Transform player;
    public Transform toilet;
    private float maxDistance = 27;
    private float maxStalagmiteHeight = -10;
    private float heightDiff;

    private float initialHeight;



    // Use this for initialization
    void Start () {
        initialHeight = stalagmite.position.y;
        heightDiff = maxStalagmiteHeight - initialHeight;
    }
	
	// Update is called once per frame
	void Update () {
        float distance = toilet.position.x - player.position.x;
        float distancePercent = ((maxDistance - distance) / maxDistance);

        float height = initialHeight + distancePercent * heightDiff;
        if (height < maxStalagmiteHeight)
        {
            stalagmite.position = new Vector3(stalagmite.position.x, height, stalagmite.position.z);
        }

    }
}
