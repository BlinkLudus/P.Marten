using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//FallingAttackProgram
//Coded on 23/5/23 by Ricky Wilkinson

public class FallingAttack : MonoBehaviour
{
    public GameObject spritePrefab;
    public int numAttacks = 10;
    public float spawnDelay = 2f;
    public float spawnHeight = 10f;
    public float bossHealthThreshold = 0.7f;

    private int attacksRemaining;
    private bool isAttacking;

    private void Update()
    {
        if (!isAttacking && IsBossHealthBelowThreshold())
        {
            StartAttack();
        }
    }

    private bool IsBossHealthBelowThreshold()
    {
        return GetBossHealth() < bossHealthThreshold;
    }

    private float GetBossHealth()
    {
        // Replace with your own boss health retrieval logic
        return 1f;
    }

    private void StartAttack()
    {
        isAttacking = true;
        attacksRemaining = numAttacks;
        InvokeRepeating("SpawnSprite", 0f, spawnDelay);
    }

    private void SpawnSprite()
    {
        if (attacksRemaining <= 0)
        {
            StopAttack();
            return;
        }

        attacksRemaining--;

        float randomX = Random.Range(-Camera.main.orthographicSize * Camera.main.aspect,
                                      Camera.main.orthographicSize * Camera.main.aspect);

        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0f);
        Instantiate(spritePrefab, spawnPosition, Quaternion.identity);
    }

    private void StopAttack()
    {
        isAttacking = false;
        CancelInvoke("SpawnSprite");
    }
}