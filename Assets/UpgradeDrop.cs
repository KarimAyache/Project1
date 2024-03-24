using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDrop : MonoBehaviour
{
    public GameObject pickupPrefab; // Reference to the pickup prefab
    public float delayReduction = 0.1f; // Amount to reduce player's shot delay
    public float dropChance = 0.2f; // Chance of dropping the pickup (1/5)

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // Destroy the bullet object

            // Check if a pickup should be dropped
            if (Random.value <= dropChance)
            {
                DropPickup();
            }

            // Hide the object
            gameObject.SetActive(false);
        }
    }

    void DropPickup()
    {
        // Instantiate the pickup prefab at the current position
        GameObject pickup = Instantiate(pickupPrefab, transform.position, Quaternion.identity);

        // Attach a script to the pickup prefab to handle pickup functionality
        Pickup pickupScript = pickup.GetComponent<Pickup>();
        if (pickupScript != null)
        {
            // Set the delay reduction value
            pickupScript.delayReduction = delayReduction;
        }
        else
        {
            Debug.LogWarning("Pickup prefab does not have a Pickup script attached.");
        }
    }
}