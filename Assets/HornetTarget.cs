using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornetTarget : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private GameObject bullet;
    



    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
      
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collision is with a bullet
        if (other.CompareTag("Bullet"))
        {
            // Set the bullet reference
            bullet = other.gameObject;

            // Trigger the death animation
            animator.SetTrigger("DieTrigger");

            // Disable collider and other components (optional)
            // GetComponent<Collider2D>().enabled = false;

            // Disable Rigidbody2D component to prevent physics interactions
            rb.bodyType = RigidbodyType2D.Static;

            // Call the DestroyBullet method on the bullet object
            DestroyBullet();

            // Destroy the spider after the death animation finishes
            Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
        }

        // Check if the collision is with a bullet
       
    }

    // Method to destroy the bullet
    void DestroyBullet()
    {
        // Check if the bullet exists and has a BulletDestroy component
        if (bullet != null)
        {
            BulletDestroy bulletDestroy = bullet.GetComponent<BulletDestroy>();
            if (bulletDestroy != null)
            {
                // Call the DestroyBullet method on the BulletDestroy component
                bulletDestroy.DestroyPrefab();
            }
            else
            {
                // Destroy the bullet directly if BulletDestroy component is missing
                Destroy(bullet);
            }
        }
    }

    





}
