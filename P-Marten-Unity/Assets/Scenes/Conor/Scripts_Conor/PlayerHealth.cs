using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 3;
    public int currentHealth;
    public string targetScene = "";

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
            //Kill();
            ChangeScene();
            
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

   public int GetHealth()
    {
        return currentHealth;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(targetScene);
    }
}
