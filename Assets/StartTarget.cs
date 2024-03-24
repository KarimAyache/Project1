using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTarget : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision is with an object tagged as "Bullet"
        if (other.CompareTag("Bullet"))
        {
            // Destroy the object
            Destroy(gameObject);
        }
    }

}
