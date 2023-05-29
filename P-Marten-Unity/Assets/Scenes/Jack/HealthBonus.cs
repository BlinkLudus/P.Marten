using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonus : MonoBehaviour
{
    PlayerHealth playerHealth;

    public float healthBonus = 1f;

    private void Awake()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (playerHealth.GetHealth() < playerHealth.startingHealth)
        {
            Destroy(gameObject);
            playerHealth.currentHealth = (int)(playerHealth.GetHealth() + healthBonus);
        }
        
    }
}
