using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonus : MonoBehaviour
{
    PlayerHealth playerHealth; // Reference to the PlayerHealth component

    public float healthBonus = 1f; // Amount of health to be added

    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>(); // Find and assign the PlayerHealth component in the scene
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) // Check if the collider's tag is "Player"
        {
            if (playerHealth.GetHealth() < playerHealth.startingHealth) // Check if the player's current health is less than the starting health
            {
                Destroy(gameObject); // Destroy the health bonus game object
                playerHealth.currentHealth = (int)(playerHealth.GetHealth() + healthBonus); // Add the health bonus to the player's current health
            }
        }
    }
}
