using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private Collision currentCollision;

    void Update()
    {
        // Check for mouse click and current collision
        if (currentCollision != null && Input.GetMouseButtonDown(0))
        {
            Transform parent = currentCollision.transform.parent;

            // Debugging: Check if a parent exists
            Debug.Log("Parent exists: " + (parent != null));

            if (parent != null)
            {
                Debug.Log("Destroying Parent Object: " + parent.gameObject.name);
                Destroy(parent.gameObject); // Destroy the parent object
            }
        }
    }

    // Triggered when a collision starts
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object has the "Kill" tag
        if (collision.gameObject.CompareTag("Kill"))
        {
            currentCollision = collision; // Store the collision
            Debug.Log("Collision with Kill object detected: " + collision.gameObject.name);
        }
    }

    // Triggered when the collision ends
    private void OnCollisionExit(Collision collision)
    {
        // Reset the collision when it exits
        if (collision == currentCollision)
        {
            Debug.Log("Collision with Kill object ended: " + collision.gameObject.name);
            currentCollision = null;
        }
    }
}
