using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButtonImStupid : MonoBehaviour {

    public float maxheight;
    private float minheight;

	// Use this for initialization
	void Start () {
        minheight = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y >= maxheight)
        {
            transform.position = new Vector3(transform.position.x, maxheight, transform.position.z);
        }
        else if(transform.position.y <= minheight)
        {
            transform.position = new Vector3(transform.position.x, minheight, transform.position.z);
        }
	}
}
