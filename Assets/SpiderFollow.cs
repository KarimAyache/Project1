using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderFollow : MonoBehaviour
{
    public float speed = 3f; // Speed of the spider

    private GameObject[] players; // Array to store player objects

    void Start()
    {
        // Find all game objects with the Player tag and store them in the players array
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {
        // Check if there are any player objects in the scene
        if (players.Length > 0)
        {
            // Find the closest player object
            GameObject closestPlayer = FindClosestPlayer();

            if (closestPlayer != null)
            {
                // Calculate direction to the closest player
                Vector3 direction = (closestPlayer.transform.position - transform.position).normalized;

                // Move towards the closest player
                transform.Translate(direction * speed * Time.deltaTime);
            }
        }
    }

    GameObject FindClosestPlayer()
    {
        GameObject closestPlayer = null;
        float closestDistance = Mathf.Infinity;

        // Iterate through all player objects to find the closest one
        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPlayer = player;
            }
        }

        return closestPlayer;
    }
}
