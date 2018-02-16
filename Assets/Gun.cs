using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    ControllerInteraction[] controllers;
    public GameObject bullet, slide;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Shoot()
    {
        Instantiate(bullet, slide.transform.position, slide.transform.rotation);
    }
}
