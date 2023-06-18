using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    // Amount of damage the bullet does
    public int bulletDamage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider; // Object we collided with
        BossHealth boss = collider.GetComponent<BossHealth>();// This gets the BossHealth script attached to that object

        // Checks if we actually find a BossHealth script
        // This statement is true if the player variable is NOT null (empty)
        if (boss != null) 
        {
            boss.ChangeHealth(-bulletDamage);// Boss health will decrease when boss is hit by a bullet
            Destroy(gameObject);// Destroys the bullet object
        }

    }
}
