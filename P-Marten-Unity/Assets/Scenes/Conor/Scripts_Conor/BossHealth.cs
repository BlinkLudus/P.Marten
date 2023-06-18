using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int bStartingHealth = 3;
    private int bCurrentHealth;
    public string targetScene = "";

    private void Awake()
    {
        // Initialise boss current health to be equal to
        // the bosses starting health at the beginning of the game.
        bCurrentHealth = bStartingHealth;
    }

    public void ChangeHealth(int changeAmount)
    {
        // Take boss' current health, add the change amount, and store the result back in the current health variable
        bCurrentHealth = bCurrentHealth + changeAmount;
        // Keep our currentHealth between 0 and starting health value
        bCurrentHealth = Mathf.Clamp(bCurrentHealth, 0, bStartingHealth);

        if (bCurrentHealth == 0)
        {
            // Call kill function to kill player
            Kill();
            ChangeScene();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    // This is a custom getter function which gives info to the calling node
    // the int is type of info that will be given
    public int GetHealth()
    {
        // return will give the following info back to the player
        return bCurrentHealth;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(targetScene);
    }
}
