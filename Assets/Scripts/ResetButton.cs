using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour {

    private BasketballScoreboard scoreboard;
	// Use this for initialization
	void Start () {
        scoreboard = GameObject.FindObjectOfType<BasketballScoreboard>();
    }
	
	// Update is called once per frame
	void Update () {
		//ToDo
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BBResetCube"))
        {
            scoreboard.ResetGame();
        }
    }
}
