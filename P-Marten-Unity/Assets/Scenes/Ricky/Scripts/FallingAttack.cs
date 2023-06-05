using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//FallingAttackProgram
//Coded on 23/5/23 by Ricky Wilkinson

public class FallingAttack : MonoBehaviour
{
    public GameObject spritePrefab; // Reference to the sprite prefab object
    public int numAttacks = 1; // Number of attacks the boss can perform
    public float spawnDelay = 60f; // Delay between each sprite spawn
    public float spawnHeight = 10f; // Height at which sprites are spawned
    public float BossHealth = 7f; // Health threshold below which the boss will start attacking

    private int attacksRemaining; // Number of remaining attacks
    private bool isAttacking; // Flag indicating if the boss is currently attacking

    private void Update()
    {
        if (!isAttacking && IsBossHealthBelowThreshold())
        {
            StartAttack(); // Start the attack if the boss health is below the threshold
        }
    }

    private bool IsBossHealthBelowThreshold()
    {
        return GetBossHealth() < BossHealth; // Check if the boss health is below the threshold
    }

    private float GetBossHealth()
    {
        return 1f; // Placeholder to retrieve the boss's health
    }

    private void StartAttack()
    {
        isAttacking = true; // Set the attacking flag to true
        attacksRemaining = numAttacks; // Initialize the number of remaining attacks
        InvokeRepeating("SpawnSprite", 0f, spawnDelay); // Start spawning sprites with the specified delay
    }

    private void SpawnSprite()
    {
        if (attacksRemaining <= 0)
        {
            StopAttack(); // If there are no remaining attacks, stop the attack
            return;
        }

        attacksRemaining--; // reduce the number of remaining attacks

        // Generate a random X position within the screen bounds
        float randomX = Random.Range(-Camera.main.orthographicSize * Camera.main.aspect,
                                      Camera.main.orthographicSize * Camera.main.aspect);

        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0f); // Calculate the spawn position
        Instantiate(spritePrefab, spawnPosition, Quaternion.identity); // Create a new sprite at the spawn position
    }

    private void StopAttack()
    {
        isAttacking = false; // Set the attacking flag to false
        CancelInvoke("SpawnSprite"); // Stop spawning sprites
    }
}