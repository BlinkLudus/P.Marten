using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 3; // Players starting health
    public int currentHealth; // Players Current health
    public string targetScene = "";

    private void Awake()
    {
        // Initialise our current health to be equal to
        // our starting health at the beginning of the game.
        currentHealth = startingHealth;
    }

    public void ChangeHealth(int changeAmount)
    {
        // Take our current health, add the change amount, and store the result back in the current health variable
        currentHealth = currentHealth + changeAmount;
        // Keep our currentHealth between 0 and starting health value
        currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);

        if (currentHealth == 0)
        {
            // Call kill function to kill player
            // Kill();
            ChangeScene();
            
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    // This simple function will let other scripts ask this one what the current health is
    // the function RETURNS an integer, meaning it gives a number back to the code that called it
    public int GetHealth() 
    {
        return currentHealth;
    }

    // This funtion changes the scene when the player dies
    public void ChangeScene()
    {
        SceneManager.LoadScene(targetScene);
    }
}
