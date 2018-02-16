using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        AudioSource asource = GetComponent<AudioSource>();
        asource.pitch = (Random.Range(0.0f, 1.0f));
        asource.Play();
    }
}
