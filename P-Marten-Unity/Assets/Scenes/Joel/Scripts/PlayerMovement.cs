using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D physicsBody;
    public float speed = 1f;
    public float jumpSpeed = 10f;
    public float jumpDeadZone = 0.5f;
    public Collider2D groundSensor;
    public LayerMask groundLayer;
    public FixedJoystick joystick;
    public float jumpCooldown = 1f; // Cooldown time between jumps
    private float jumpTimer = 0f; // Timer to track jump cooldown

    private void Awake()
    {
        physicsBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = joystick.Horizontal;
        float verticalInput = joystick.Vertical;

        HandleMovement(horizontalInput);
        HandleJump(verticalInput);
    }

    private void HandleMovement(float horizontalInput)
    {
        if (horizontalInput < 0 || horizontalInput > 0)
        {
            Move(horizontalInput);
        }
    }

    private void HandleJump(float verticalInput)
    {
        if (verticalInput > jumpDeadZone && groundSensor.IsTouchingLayers(groundLayer) && jumpTimer <= 0f)
        {
            Jump();
            jumpTimer = jumpCooldown;
        }

        // Update the jump timer
        if (jumpTimer > 0f)
        {
            jumpTimer -= Time.deltaTime;
        }
    }

    private void Move(float horizontalInput)
    {
        Vector2 newVelocity = physicsBody.velocity;
        newVelocity.x = horizontalInput * speed;
        physicsBody.velocity = newVelocity;
    }

    private void Jump()
    {
        Vector2 newVelocity = physicsBody.velocity;
        newVelocity.y = jumpSpeed;
        physicsBody.velocity = newVelocity;
    }
}





