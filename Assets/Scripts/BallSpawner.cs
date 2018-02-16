using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {

    public GameObject balls;
    private GameObject[] currentBalls;
    private GameObject ballholder;
    private BasketballScoreboard scoreboard;

    private void Start()
    {
        scoreboard = GameObject.FindObjectOfType<BasketballScoreboard>();
        ballholder = GameObject.Find("Balls");
    }

    private void Update()
    {
        currentBalls = GameObject.FindGameObjectsWithTag("Basketball");
        if (currentBalls.Length <= 0)
        {
            scoreboard.ResetGame();
            Destroy(ballholder);
            SpawnBalls();
        }
    }
    public void SpawnBalls()
    {
        GameObject newballs = Instantiate(balls, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        newballs.transform.parent = this.transform;
    }
}
