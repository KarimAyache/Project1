using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderCollision : MonoBehaviour
{
    private bool hasCollided = false; // To prevent multiple collisions
    private Animator animator;

    private void Update()
    {
        // Check for collisions only if a collision hasn't already occurred
        if (!hasCollided)
        {
            CheckCollision();
        }
    }

    private void CheckCollision()
    {
        Debug.Log("Checking collision...");
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f); // Adjust radius as needed

        foreach (Collider2D collider in colliders)
        {
            Debug.Log("Collider tag: " + collider.tag);
            if (collider.CompareTag("Player"))
            {
                Debug.Log("Player detected!");
                // Get the Spider_target component attached to the spider
                Spider_target spiderTarget = GetComponent<Spider_target>();

                // Check if the Spider_target component exists
                if (spiderTarget != null)
                {
                    Debug.Log("Triggering death...");
                    // Trigger the death animation and destroy the spider
                    animator.SetTrigger("DieTrigger");
                    hasCollided = true; // Mark collision as occurred to prevent multiple calls
                    break; // Exit loop as collision detected
                }
                else
                {
                    Debug.LogWarning("Spider_target component not found on the spider.");
                }
            }
        }
    }




}



