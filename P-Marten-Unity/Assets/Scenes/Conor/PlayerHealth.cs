using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 3;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void ChangeHealth(int changeAmount)
    {
        currentHealth = currentHealth + changeAmount;
        // Keep our currentHealth between 0 and starting health value
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);

        if (currentHealth == 0)
        {
            // Call kill function to kill player
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

   
}
