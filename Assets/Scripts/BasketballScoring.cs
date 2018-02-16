using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketballScoring : MonoBehaviour
{
    public float score;
    private BallSpawner ballSpawner;
    private BasketballScoreboard scoreboard;

    // Use this for initialization
    void Start()
    {
        scoreboard = GameObject.FindObjectOfType<BasketballScoreboard>();
        ballSpawner = GameObject.FindObjectOfType<BallSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basketball"))
        {
            scoreboard.AddScore(score);
            Destroy(other.gameObject);
        }
    }
}
