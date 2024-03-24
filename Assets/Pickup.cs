using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float delayReduction = 0.1f; // Amount to reduce player's shot delay
    public float duration = 5f; // Duration of the delay reduction

    private bool pickedUp = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!pickedUp && other.CompareTag("Player"))
        {
            // Assuming the player has a Shooting script attached
            Shooting shootingScript = other.GetComponent<Shooting>();
            if (shootingScript != null)
            {
                // Reduce the player's shot delay
                shootingScript.ReduceShotDelay(delayReduction);

                // Set pickedUp to true to prevent multiple pickups
                pickedUp = true;

                // Start the duration countdown
                Invoke("ResetDelay", duration);

                // Destroy the pickup object
                Destroy(gameObject);
            }
        }
    }

    void ResetDelay()
    {
        // Assuming the player has a Shooting script attached
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Shooting shootingScript = player.GetComponent<Shooting>();
            if (shootingScript != null)
            {
                // Restore the player's shot delay after the duration
                shootingScript.RestoreShotDelay(delayReduction);
            }
        }
    }
}



