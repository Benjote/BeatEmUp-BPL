using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 50f;
    public float jumpForce = 8f; // Ajusta la fuerza de salto desde el inspector
    public Transform groundCheck;
    public Animator animator;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        // Movimiento
        transform.position += movementDirection * speed * Time.deltaTime; ;
        
        // rb.MovePosition(rb.position + movement);

        // Rotación
        Quaternion targetRotation = Quaternion.LookRotation(movementDirection);;

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("Jumping");
        }

    }

    private bool IsGrounded()
    {
        return Physics.Raycast(groundCheck.position, Vector3.down, 0.1f);
    }
}