using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float AISpeed; // Speed of the NPC
    private Transform player; // Reference to the player's Transform

    void Start()
    {
        // Find the GameObject tagged "Player" and get its Transform
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("No GameObject with the tag 'Player' found in the scene.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Move toward the player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * AISpeed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision enemy)
    {
        if (enemy.gameObject.CompareTag("Player"))
        {
            Destroy(enemy.gameObject); // Destroy the player if the NPC collides with it
        }
    }
}
