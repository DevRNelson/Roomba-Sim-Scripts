using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    private Vector3 respawnPosition;

    void Start()
    {
        // Set initial respawn position to the player's starting position
        respawnPosition = transform.position;
    }

    void Update()
    {
        // Check if the player presses the "R" key
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Respawn the player at the stored position
            transform.position = respawnPosition;
        }
    }

    public void SetRespawnPosition(Vector3 newPosition)
    {
        // Update the respawn position
        respawnPosition = newPosition;
    }
}