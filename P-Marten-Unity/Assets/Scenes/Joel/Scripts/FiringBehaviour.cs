using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringBehaviour : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletspeed = 10;
    public float shootDelay = 1.0f; // Delay between shots

    private bool canShoot = true; // Flag to control shooting

    public void Shoot()
    {
        if (canShoot)
        {
            StartCoroutine(ShootWithDelay());
            canShoot = false; // Disable shooting until the delay is over
        }
    }

    private IEnumerator ShootWithDelay()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * bulletspeed;

        yield return new WaitForSeconds(shootDelay);

        canShoot = true; // Enable shooting after the delay
    }
}
