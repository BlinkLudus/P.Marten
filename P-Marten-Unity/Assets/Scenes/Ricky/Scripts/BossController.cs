using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Boss Passive Attack Code
//Coded on 22/5/23 by Ricky Wilkinson

public class BossController : MonoBehaviour
{
    // Declaring Variables
    public Animator bossAnimator;  // Reference to the Animator component for the boss
    public Transform playerTransform;  // Reference to the player's Transform component
    public float attackDistance = 2f;  // The maximum distance at which the boss can attack the player
    public string attackTrigger = "Attack";  // The trigger parameter name in the boss's animator controller for the attack animation

    private void Update()
    {
        // Measures the distance between the boss and the player
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        // If the player is within the attack distance, the boss will initiate his attack
        if (distance <= attackDistance)
        {
            bossAnimator.SetTrigger(attackTrigger);  // Triggers the attack animation in the boss's animator controller
        }
    }
}


