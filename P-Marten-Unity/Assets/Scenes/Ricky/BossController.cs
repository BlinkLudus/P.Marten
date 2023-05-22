using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Boss Passive Attack Code
//Coded on 22/5/23 by Ricky Wilkinson

public class BossController : MonoBehaviour
{
 //Declaring Variables 
 public Animator bossAnimator;
 public Transform playerTransform;
 public float attackDistance = 1.5f;
 public string attackTrigger = "Attack";

private void Update()
{
    // Measures the distance between the boss and the player
    float distance = Vector3.Distance(transform.position, playerTransform.position);

    // If the player is within the attack distance, the boss will initiate his attack
    if (distance <= attackDistance)
        {
            bossAnimator.SetTrigger(attackTrigger);
        }
    }
}


