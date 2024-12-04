using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float gravity = -9.81f;

    private CharacterController characterController;
    private Vector3 velocity;
    private bool isGrounded;

    private PlayerInputActions inputActions;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        inputActions = new PlayerInputActions();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Jump.performed += OnJump;
    }

    private void OnDisable()
    {
        inputActions.Player.Disable();
        inputActions.Player.Jump.performed -= OnJump;
    }

    private void FixedUpdate()
    {
        Move();
        ApplyGravity();
    }

    private void Move()
    {
        isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f; // Reset vertical velocity when grounded
        }

        Vector2 input = inputActions.Player.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        characterController.Move(move * moveSpeed * Time.deltaTime);
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("click jump" + isGrounded);
        if (characterController.isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpForce * -2f * gravity);
        }
    }

    private void ApplyGravity()
    {
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}