using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasePlayer: NetworkBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private float maxSpeed = 2f;
    [SerializeField] private float forceJump = 2f;
    private bool _isUpdateMovement = true;
    
    private Rigidbody _rb;
    private PlayerInputActions _playerInput;

    public void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _playerInput = new PlayerInputActions();
        _playerInput.Player.Enable();
        _playerInput.Player.Jump.performed += Jump;
    }

    private void FixedUpdate()
    {
        if (_isUpdateMovement)
        {
            UpdateMovement();
        }
    }

    private void UpdateMovement()
    {
        //input
        var input = _playerInput.Player.Move.ReadValue<Vector2>();
        ApplyForce(GetHorizontalVelocity(input));
    }

    private Vector3 GetHorizontalVelocity(Vector2 inputHorizontal)
    {
        var rbMagnitudeHor = new Vector2(_rb.linearVelocity.x, _rb.linearVelocity.z).sqrMagnitude;
        var speed = Mathf.Clamp(inputHorizontal.sqrMagnitude * movementSpeed, 0, maxSpeed);
        
        var horizontalVelocity = new Vector3(inputHorizontal.x * speed, 0, inputHorizontal.y * speed);
        // if (inputHorizontal.sqrMagnitude < 0.3f)
        // {
        //     Debug.Log(inputHorizontal.sqrMagnitude);
        //     horizontalVelocity = new Vector3(_rb.linearVelocity.x/1.01f, 0, _rb.linearVelocity.z/1.01f);
        // }
        
        return horizontalVelocity;
    }
    private void ApplyForce(Vector3 horizontalVelocity)
    {
        _rb.linearVelocity = new Vector3(horizontalVelocity.x, _rb.linearVelocity.y, horizontalVelocity.z);
        Debug.Log(horizontalVelocity);
    }

    private void Jump(InputAction.CallbackContext context)
    {
        transform.GetComponent<Rigidbody>().AddForce(Vector3.up * forceJump, ForceMode.Impulse);
    }
}