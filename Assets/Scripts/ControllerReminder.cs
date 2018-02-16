using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerReminder : MonoBehaviour {

    public GameObject controllerReminder;
    public GameObject left, right;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (left.activeInHierarchy || right.activeInHierarchy)
        {
            controllerReminder.SetActive(false);
        }
        else
        {
            controllerReminder.SetActive(true);
        }
	}
}
