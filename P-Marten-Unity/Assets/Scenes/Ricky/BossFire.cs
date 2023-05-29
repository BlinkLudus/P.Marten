using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire : MonoBehaviour
{
    //Unity editor variable
    public GameObject projectilePrefab;
    GameObject clonedProjectile;
    Rigidbody2D projectileRigidbody;
    public Vector2 projectileVelocity;
    public Vector3 offset;
    //ACTION: Fire a projectile
    public void FireProjectile()
    {
        //Position on the boss
        clonedProjectile = Instantiate(projectilePrefab);
        clonedProjectile.transform.position = transform.position + offset;

        //Get rigidbody from cloned projectile and store it
        projectileRigidbody = clonedProjectile.GetComponent<Rigidbody2D>();

        //Setting velocity on the rigid body to the editor setting
        projectileRigidbody.velocity = projectileVelocity;
    }
}
