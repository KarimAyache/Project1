using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    void Update()
    {
        Cursor.visible = false;
        // Get the position of the mouse cursor
        Vector3 cursorPosition = Input.mousePosition;
        cursorPosition.z = -Camera.main.transform.position.z; // Set the Z distance of the cursor from the camera

        // Convert the cursor position from screen space to world space
        Vector3 worldCursorPosition = Camera.main.ScreenToWorldPoint(cursorPosition);

        // Update the position of the object to follow the cursor
        transform.position = worldCursorPosition;
    }
}
