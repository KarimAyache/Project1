using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab; // Reference to the bullet prefab

    public void DestroyPrefab()
    {
        if (bulletPrefab != null)
        {
            Destroy(bulletPrefab);
        }
    }
}