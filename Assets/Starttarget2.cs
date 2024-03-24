using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starttarget2 : MonoBehaviour

   {
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision is with an object tagged as "Bullet"
        if (other.CompareTag("Bullet"))
        {
            // Find all game objects with the tag "StartTarget" and destroy them
            GameObject[] startTargets = GameObject.FindGameObjectsWithTag("StartTarget");
            foreach (GameObject startTarget in startTargets)
            {
                Destroy(startTarget);
            }
        }
    }
}

