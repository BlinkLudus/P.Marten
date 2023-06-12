using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringBehaviour : MonoBehaviour
{
    [System.Serializable]
    public class ShootingSettings
    {
        public float bulletSpeed = 10f;
        public float shootDelay = 1.0f;
        public float clipSize = 9f;
        public float reloadTimer = 2f;
    }

    [System.Serializable]
    public class VisualSettings
    {
        public GameObject bulletPrefab;
        public Transform bulletSpawnPoint;
        public GameObject reloadIndicator;
    }

    [SerializeField] private ShootingSettings shootingSettings;
    [SerializeField] private VisualSettings visualSettings;

    private bool canShoot = true; // Flag to control shooting
    private int bulletsShot = 0; // Counter for bullets shot

    private void Start()
    {
        visualSettings.reloadIndicator.SetActive(false);
    }

    public void Shoot()
    {
        if (canShoot)
        {
            audioSource.Play();
            bulletsShot++;
            StartCoroutine(ShootWithDelay());
            canShoot = false; // Disable shooting until the delay is over
        }
    }

    private IEnumerator ShootWithDelay()
    {
        var bullet = Instantiate(visualSettings.bulletPrefab, visualSettings.bulletSpawnPoint.position, visualSettings.bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = visualSettings.bulletSpawnPoint.right * shootingSettings.bulletSpeed;

        yield return new WaitForSeconds(shootingSettings.shootDelay);

        if (bulletsShot % shootingSettings.clipSize == 0) // Check if 9 bullets have been shot
        {
            canShoot = false;
            visualSettings.reloadIndicator.SetActive(true); // Show the reload indicator
            yield return new WaitForSeconds(shootingSettings.reloadTimer);
            visualSettings.reloadIndicator.SetActive(false); // Hide the reload indicator
            canShoot = true; // Enable shooting after the delay
        }
        else
        {
            canShoot = true; // Enable shooting after the delay
        }
    }
}




