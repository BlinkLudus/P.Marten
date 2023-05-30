using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int bStartingHealth = 3;
    private int bCurrentHealth;

    private void Awake()
    {
        bCurrentHealth = bStartingHealth;
    }

    public void ChangeHealth(int changeAmount)
    {
        bCurrentHealth = bCurrentHealth + changeAmount;
        // Keep our currentHealth between 0 and starting health value
        bCurrentHealth = Mathf.Clamp(bCurrentHealth, 0, bStartingHealth);

        if (bCurrentHealth == 0)
        {
            // Call kill function to kill player
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public int GetHealth()
    {
        return bCurrentHealth;
    }
}
