using Unity.Netcode;
using UnityEngine;

public class Player: NetworkBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private float rotationSpeed = 500F;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        var movementDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        movementDirection.Normalize();

        transform.Translate(movementDirection * movementSpeed * Time.deltaTime, Space.World);

        if (movementDirection != Vector3.zero)
        {
            var toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        animator.SetFloat("run", movementDirection.magnitude);
    }
}