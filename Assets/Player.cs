using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharacterMovement : MonoBehaviour
{
    public float speed = 5f; // Movement speed
   
    

    void Update()
    {
        // Movement input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate movement vector
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f).normalized * speed * Time.deltaTime;

        // Move the character
        transform.Translate(movement);

        // Get the mouse position in world coordinates
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Flip the character based on the cursor position
        FlipCharacter(mousePosition.x);

    }



    void FlipCharacter(float mouseX)
    {
        // Flip the character if the mouse is to the left of the character
        if (mouseX < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Flip character to face left
        }
        // Flip the character if the mouse is to the right of the character
        else if (mouseX > transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1); // Flip character to face right
        }
        // If the mouse is directly above or below the character, do not flip
    }

}





