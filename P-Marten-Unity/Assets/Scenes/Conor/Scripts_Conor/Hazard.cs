using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    // Amount of damage the hazard does
    public int hazardDamage = 1;

    // Built in unity function for handling collisions
    // This function will be called when another object collides
    // into the one this script is attached to
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Collider2D collider = collision.collider; // Object we collided with
        PlayerHealth player = collider.GetComponent<PlayerHealth>(); // This gets the PlayerHealth script attached to that object

        // Checks if we actually find a PLayerHealth script
        // This statement is true if the player variable is NOT null (empty)
        if (player != null)
        {
            player.ChangeHealth(-hazardDamage); // Players health changes based on the hazard damage.
            Destroy(gameObject); // Destroys the hazard after it has collided with the player
        }
        
    }


}
