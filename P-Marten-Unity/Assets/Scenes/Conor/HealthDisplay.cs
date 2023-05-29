using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    // This will contain a list of the game objects for the health icons
    public GameObject[] healthIcons;

    // This will contain the player health component that is on the player game object
    // So we can ask it for info about the player's health
    PlayerHealth player;

    // Start is called before the first frame update
    void Start()
    {
        // Search the scene for the object with PlayerHealth attached
        // Store the PlayerHealth component from that object in our player variable
        player = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        // Create a varibale to keep track of which item of the list we are on
        // and how much health that icon is worth
        int iconHealth = 0;

        //Go through each icon in the list
        //We will do everything inside the brackes for each item in the list
        //For each step in the loop , we'll store the current list item in the "icon" variable
        foreach (GameObject icon in healthIcons)
        {
            //Each icon is worth one more health than the last
            //So we get the current health and add one to it and store the result back into the iconHealth variable
            iconHealth = iconHealth + 1;

            if(player.currentHealth >= iconHealth)
        }
    }
}
