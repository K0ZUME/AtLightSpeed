using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstacle;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float timeBetweenSpawn;
    private float spawnTime;

    private float currentScore;
    private float previousScore;

    void Update()
    {
        if (Time.time > spawnTime)
        {
            Spawn();
            spawnTime = Time.time + timeBetweenSpawn;
        }
    }

    void Spawn()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Instantiate(obstacle, transform.position + new Vector3(randomX, randomY, -1), transform.rotation);
    }

    public void UpdateScore(float score)
    {
        currentScore = score;

        if (currentScore <= 15)
        {
            if (Mathf.Floor(previousScore) != Mathf.Floor(currentScore))
            {
                timeBetweenSpawn -= currentScore / 220;
                previousScore = currentScore;
            }
        }
    }
}
