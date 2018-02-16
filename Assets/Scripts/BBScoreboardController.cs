using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBScoreboardController : MonoBehaviour {

    private BasketballScoreboard scoreboard;

    private void Start()
    {
        scoreboard = GameObject.FindObjectOfType<BasketballScoreboard>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scoreboard.enableScoreboard();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            scoreboard.disableScoreboard();
        }
    }
}
