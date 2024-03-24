using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour


{
    public Transform target; // Reference to the character's transform
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Offset of the camera from the character
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        if (target != null)
        {
            // Set the position of the camera to the character's position plus the offset
            transform.position = target.position + offset;
        }


        if (target != null)
        {
            // Calculate the desired position for the camera
            Vector3 desiredPosition = target.position;
            // Ensure the camera stays at its original Z position
            desiredPosition.z = transform.position.z;

            // Smoothly move the camera towards the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}

