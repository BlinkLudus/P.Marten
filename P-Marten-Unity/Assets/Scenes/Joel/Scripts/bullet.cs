using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float life = 3;
    public GameObject impactEffect; // Reference to the impact effect prefab
    public float gravityScale = 1f; // Gravity scale for the rigid body

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;

        Destroy(gameObject, life);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Spawn the impact effect at the collision point
        Instantiate(impactEffect, collision.contacts[0].point, Quaternion.identity);

        // Destroy the bullet
        Destroy(gameObject);
    }
}


