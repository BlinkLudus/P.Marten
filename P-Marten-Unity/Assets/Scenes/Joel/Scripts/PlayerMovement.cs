using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // need the play to have a rigid body
public class PlayerMovement : MonoBehaviour
{
    [System.Serializable] // Sorts the variables into categories
    public class MovementSettings
    {
        public float speed = 1f; // characters horizontal movements speed
        public float jumpSpeed = 10f; // affects height the player jumps
        public float jumpDeadZone = 0.5f; // how far up does the joystick need to be to jump
        public float jumpCooldown = 1f; // Cooldown time between jumps
    }

    [System.Serializable]
    public class Colliders
    {
        public Collider2D groundSensor; // checks if the player is on the ground
        public LayerMask groundLayer; // decides what the ground is
    }

    [System.Serializable]
    public class InputSettings
    {
        public FixedJoystick joystick;
    }

    [SerializeField] private MovementSettings movementSettings;
    [SerializeField] private Colliders colliders;
    [SerializeField] private InputSettings inputSettings;

    private Rigidbody2D physicsBody;
    private float jumpTimer = 0f; // Timer to track jump cooldown

    private void Awake()
    {
        physicsBody = GetComponent<Rigidbody2D>(); // get the player rigid body once the game starts
    }

    private void Update()
    {
        float horizontalInput = inputSettings.joystick.Horizontal; // get the players left and right input on the thumbstick
        float verticalInput = inputSettings.joystick.Vertical; // get the player up and down input on the thumbstick

        HandleMovement(horizontalInput); // sends the input values to a movement function
        HandleJump(verticalInput); // sends the input values to a jump handler
    }

    private void HandleMovement(float horizontalInput)
    {
        if (horizontalInput < 0 || horizontalInput > 0)
        {
            Move(horizontalInput); // sends the input to a move function if the player is actually moveming the thumbstick
        }
    }

    private void HandleJump(float verticalInput)
    {
        if (verticalInput > movementSettings.jumpDeadZone && colliders.groundSensor.IsTouchingLayers(colliders.groundLayer) && jumpTimer <= 0f) // if the player is on the ground and the jump timer is reset
        {
            Jump();
            jumpTimer = movementSettings.jumpCooldown;
        }

    
        if (jumpTimer > 0f)
        {
            jumpTimer -= Time.deltaTime;    // Update the jump timer
        }
    }

    private void Move(float horizontalInput)
    {
        Vector2 newVelocity = physicsBody.velocity;
        newVelocity.x = horizontalInput * movementSettings.speed;// add velocity to the player to move them left or right
        physicsBody.velocity = newVelocity;
    }

    private void Jump()
    {
        Vector2 newVelocity = physicsBody.velocity; // add veloctiy to the player to move them up when they jump
        newVelocity.y = movementSettings.jumpSpeed;
        physicsBody.velocity = newVelocity;
    }
}






