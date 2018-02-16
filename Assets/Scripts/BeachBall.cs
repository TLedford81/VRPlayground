using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeachBall : MonoBehaviour {

    private Vector3 ballRespawnCoords;

    private void Start()
    {
        ballRespawnCoords = transform.position;
    }

    public void Respawn()
    {
        transform.position = ballRespawnCoords;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        GetComponent<Rigidbody>().isKinematic = false;
        gameObject.transform.SetParent(null);
    }
}
