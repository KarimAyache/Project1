using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform bulletFirePoint; // Point where bullets will be instantiated
    public Transform muzzleFlashFirePoint; // Point where the muzzle flash will be instantiated
    public GameObject muzzleFlashPrefab; // Reference to the muzzle flash prefab
    public float bulletSpeed = 10f; // Speed of the bullets
    public float baseShotDelay = 0.5f; // Base delay between shots
    public float flashDuration = 0.1f; // Duration of the muzzle flash
    private float lastFireTime; // Time when the last shot was fired
    private float currentShotDelay; // Current delay between shots

    void Start()
    {
        currentShotDelay = baseShotDelay;
    }

    void Update()
    {
        // Check if enough time has passed to allow another shot
        if (Time.time - lastFireTime >= currentShotDelay)
        {
            // Check for left mouse button click
            if (Input.GetButtonDown("Fire1"))
            {
                // Fire the bullet
                Shoot();
                // Update the last fire time
                lastFireTime = Time.time;
            }
        }
    }

    void Shoot()
    {
        // Calculate direction from fire point to mouse position
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10f; // Distance from the camera
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 direction = (targetPosition - bulletFirePoint.position).normalized;

        // Instantiate a bullet at the bullet fire point
        GameObject bulletObject = Instantiate(bulletPrefab, bulletFirePoint.position, Quaternion.identity);

        // Get the Rigidbody2D component of the bullet
        Rigidbody2D rb = bulletObject.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Set the velocity of the bullet
            rb.velocity = direction * bulletSpeed;
            // Ensure the bullet is not affected by gravity
            rb.gravityScale = 0f;
        }
        else
        {
            Debug.LogWarning("Bullet prefab does not have a Rigidbody2D component.");
        }

        // Destroy the bullet object after some time
        Destroy(bulletObject, 2f);

        // Instantiate muzzle flash at the muzzle flash fire point
        GameObject muzzleFlash = Instantiate(muzzleFlashPrefab, muzzleFlashFirePoint.position, Quaternion.identity);

        // Destroy the muzzle flash after the specified duration
        Destroy(muzzleFlash, flashDuration);
    }

    public void ReduceShotDelay(float reductionAmount)
    {
        currentShotDelay -= reductionAmount;
        if (currentShotDelay < 0)
        {
            currentShotDelay = 0;
        }
    }

    public void RestoreShotDelay(float increaseAmount)
    {
        currentShotDelay += increaseAmount;
    }
}
