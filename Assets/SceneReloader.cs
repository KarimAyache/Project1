using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    void Update()
    {
        // Check if the "/" button is pressed
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            // Reload scene 1
            SceneManager.LoadScene(1);
        }
    }
}
