using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [System.Serializable]
    public class MovementSettings
    {
        public float speed = 1f;
        public float jumpSpeed = 10f;
        public float jumpDeadZone = 0.5f;
        public float jumpCooldown = 1f; // Cooldown time between jumps
    }

    [System.Serializable]
    public class Colliders
    {
        public Collider2D groundSensor;
        public LayerMask groundLayer;
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
        physicsBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = inputSettings.joystick.Horizontal;
        float verticalInput = inputSettings.joystick.Vertical;

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
        if (verticalInput > movementSettings.jumpDeadZone && colliders.groundSensor.IsTouchingLayers(colliders.groundLayer) && jumpTimer <= 0f)
        {
            Jump();
            jumpTimer = movementSettings.jumpCooldown;
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
        newVelocity.x = horizontalInput * movementSettings.speed;
        physicsBody.velocity = newVelocity;
    }

    private void Jump()
    {
        Vector2 newVelocity = physicsBody.velocity;
        newVelocity.y = movementSettings.jumpSpeed;
        physicsBody.velocity = newVelocity;
    }
}






