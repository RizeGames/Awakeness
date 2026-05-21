using System;
using UnityEngine;

public class PlayerConroller : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerAnimation playerAnimation;
    private CharacterController characterController;
    private Quaternion targetRotation;
    
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 500f;
    [SerializeField] private float pushPower = 5f;
    [SerializeField] private CameraController cameraController;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private Vector3 groundCheckOffset;
    [SerializeField] private LayerMask groundLayer;

    private bool isGrounded;
    private float ySpeed;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerAnimation = GetComponent<PlayerAnimation>();
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        var moveInput = (new Vector3(playerInput.HorizontalInput, 0, playerInput.VerticalInput).normalized);

        float moveAmount = Mathf.Clamp01(Mathf.Abs(playerInput.HorizontalInput) + Mathf.Abs(playerInput.VerticalInput));

        var moveDirection = cameraController.GetPlanerRotation() * moveInput;

        GroundCheck();
        
        if (isGrounded)
        {
            ySpeed = -0.5f; // small negative value to keep the player grounded
        }
        else
        {
            ySpeed += Physics.gravity.y * Time.deltaTime;
        }

        var velocity = moveDirection * moveSpeed;

        velocity.y = ySpeed;

        characterController.Move( velocity * Time.deltaTime);

        if (moveAmount > 0)
        {
            targetRotation = Quaternion.LookRotation(moveDirection);
        }

         transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        playerAnimation.SetRunAnimation(moveAmount);
    }

    void GroundCheck()
    {
        isGrounded = Physics.CheckSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius, groundLayer);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color( 0, 1, 0, 0.5f);
        Gizmos.DrawSphere(transform.TransformPoint(groundCheckOffset), groundCheckRadius);
    }

    // this method is called when the character controller collides with another collider.
    // It checks if the collider has a rigidbody attached, and if so, it applies a force to it in the direction of the collision.
    // This allows the player to push objects around in the game world.
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;

        if (rb == null) 
        {
            return;
        }

        Vector3 pushDirection = new Vector3(hit.moveDirection.x , 0 , hit.moveDirection.z);

        rb.AddForce(pushDirection * pushPower , ForceMode.Impulse);
    }
}
