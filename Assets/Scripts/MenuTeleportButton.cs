using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuTeleportButton : MonoBehaviour {


    private GameObject player;

    [Tooltip("Coordinates to teleport the player to.")]
    public Vector3 TeleportTo;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Teleport()
    {
        player.transform.position = TeleportTo;
        Debug.Log("Teleporting");
    }
}
