using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject platformPrefab;
    public Transform player;

    [Header("Start Spawn")]
    public int startPlatformCount = 12;
    public float startY = -2f;

    [Header("Spawn Area")]
    public float minX = -2.5f;
    public float maxX = 2.5f;
    public float minYStep = 1.2f;
    public float maxYStep = 2.0f;

    [Header("Spawn Ahead")]
    public float spawnAheadDistance = 12f;

    [Header("Cleanup")]
    public float destroyBelowPlayerDistance = 8f;

    private float highestSpawnY;
    private readonly List<GameObject> platforms = new List<GameObject>();

    private void Start()
    {
        GenerateStartPlatforms();
    }

    private void Update()
    {
        if (player == null || platformPrefab == null) return;

        SpawnMorePlatforms();
        CleanupPlatforms();
    }

    private void GenerateStartPlatforms()
    {
        float currentY = startY;

        for (int i = 0; i < startPlatformCount; i++)
        {
            float randomX = Random.Range(minX, maxX);
            GameObject newPlatform = Instantiate(platformPrefab, new Vector3(randomX, currentY, 0f), Quaternion.identity);

            newPlatform.tag = "Platform";
            platforms.Add(newPlatform);

            currentY += Random.Range(minYStep, maxYStep);
        }

        highestSpawnY = currentY;
    }

    private void SpawnMorePlatforms()
    {
        while (highestSpawnY < player.position.y + spawnAheadDistance)
        {
            float randomX = Random.Range(minX, maxX);
            GameObject newPlatform = Instantiate(platformPrefab, new Vector3(randomX, highestSpawnY, 0f), Quaternion.identity);

            newPlatform.tag = "Platform";
            platforms.Add(newPlatform);

            highestSpawnY += Random.Range(minYStep, maxYStep);
        }
    }

    private void CleanupPlatforms()
    {
        for (int i = platforms.Count - 1; i >= 0; i--)
        {
            if (platforms[i] == null)
            {
                platforms.RemoveAt(i);
                continue;
            }

            if (platforms[i].transform.position.y < player.position.y - destroyBelowPlayerDistance)
            {
                Destroy(platforms[i]);
                platforms.RemoveAt(i);
            }
        }
    }
}