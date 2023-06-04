using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int bulletDamage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        BossHealth boss = collider.GetComponent<BossHealth>();

        if (boss != null)
        {
            boss.ChangeHealth(-bulletDamage);
            Destroy(gameObject);
        }

    }
}
