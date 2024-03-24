using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform EnemyPrefab; // Reference to the spider prefab
    public int minSpiders = 5; // Minimum number of spiders to spawn
    public int maxSpiders = 10; // Maximum number of spiders to spawn
    public float maxSpawnRadius = 5f; // Maximum distance from the player to spawn spiders
    

    void Start()
    {
        // Find the EnemyManager in the scene
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision is with an object tagged as "Bullet"
        if (other.CompareTag("Bullet"))
        {
            // Get the position of the player
            Vector3 playerPosition = other.transform.position;

            // Calculate random number of spiders to spawn
            int numSpiders = Random.Range(minSpiders, maxSpiders + 1);

            // Spawn spiders
            for (int i = 0; i < numSpiders; i++)
            {
                // Calculate random spawn position within a circular area around the player
                Vector3 randomOffset = Random.insideUnitCircle.normalized * Random.Range(0f, maxSpawnRadius);
                Vector3 spawnPosition = playerPosition + randomOffset;

                // Instantiate the spider prefab at the calculated position
                Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
            }
        }


       
    }
    
}